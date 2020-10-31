using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace BettingGame
{
    public partial class Form1 : Form
    {
        string currentdirection = "None";
        private System.Timers.Timer timer;
        List<int> boblist = new List<int>();
        List<int> jacklist = new List<int>();
        List<int> jimlist = new List<int>();
        

        public Form1()
        {
            InitializeComponent();
            //this.timer = new System.Timers.Timer();
            boblist.Add(45);
            jacklist.Add(45);
            jimlist.Add(45);

        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            if (boblist.Count > 1)
            {
                boblist.RemoveRange(1, boblist.Count - 1);
                
            }
            if (jimlist.Count > 1)
            {
                jimlist.RemoveRange(1, jimlist.Count - 1);
                
            }
            if (jacklist.Count > 1)
            {
                jacklist.RemoveRange(1, jacklist.Count - 1);
                
            }
            foreach (var ctrl in this.Controls )
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    label2.Text = string.Empty;
                    label3.Text = string.Empty;
                    label4.Text = string.Empty;
                }
                else if (ctrl.GetType() == typeof(RadioButton))
                {
                    ((RadioButton)(ctrl)).Checked = false;
                }
                else if (ctrl.GetType() == typeof(ComboBox))
                {
                    comboBox1.Text = string.Empty;
                    comboBox2.Text = string.Empty;
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (comboBox2.SelectedItem==null)
                {
                    MessageBox.Show("Please Enter the valid amount to Bet");
                    return;

                }
                else if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Choose the car on which you want to Bet");
                    return;
                }
                label2.Text = "Bob bets an Amount $ " + this.comboBox2.SelectedItem.ToString() + " on " + this.comboBox1.SelectedItem.ToString();
            }
            else if (radioButton2.Checked)
            {
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Please Enter the valid amount to Bet");
                    return;

                }
                else if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Choose the car on which you want to Bet");
                    return;
                }
                label3.Text = "Jack bets an Amount $ " + this.comboBox2.SelectedItem.ToString() + " on " + this.comboBox1.SelectedItem.ToString();

            }
            else if (radioButton3.Checked)
            {
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Please Enter the valid amount to Bet");
                    return;

                }
                else if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Choose the car on which you want to Bet");
                    return;
                }
                label4.Text = "Jim bets an Amount $ " + this.comboBox2.SelectedItem.ToString() + " on " + this.comboBox1.SelectedItem.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
                if (label2.Text == string.Empty)
                {
                    MessageBox.Show("Select The valid player,amount and betting Car");
                return;

                }
                else if(label3.Text == string.Empty){
                MessageBox.Show("Select The valid player,amount and betting Car");
                return;

            }
            else if (label4.Text == string.Empty)
            {
                MessageBox.Show("Select The valid player,amount and betting Car");
                return;

            }

            timer1.Enabled = true;
           



        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       

       

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if ((pictureBox33.Left + 5) < (this.Width - pictureBox33.Width) & pictureBox35.Left + 7 < (this.Width - pictureBox35.Width) & (pictureBox34.Left + 8) < (this.Width - pictureBox34.Width) & (pictureBox26.Left + 8) < (this.Width - pictureBox26.Width))
            {
                pictureBox33.Left += 5;
                pictureBox35.Left += 7;
                pictureBox34.Left += 8;
                pictureBox26.Left += 9;

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (label2.Text == string.Empty)
            {
                MessageBox.Show("Select The valid player,amount and betting Car");
                return;

            }
            else if (label3.Text == string.Empty)
            {
                MessageBox.Show("Select The valid player,amount and betting Car");
                return;

            }
            else if (label4.Text == string.Empty)
            {
                MessageBox.Show("Select The valid player,amount and betting Car");
                return;

            }

            players objector = new players();
            int x = objector.RandomGenerator();
            MessageBox.Show("Congratulations ! \n Car " + x + " Wins The Race");

            // code to get the amount betted by the bob
            string text = label2.Text;
            string[] bobarr = new string[9];

            bobarr = text.Split(' ');

            //code to get the amount betted by the jack
            string text1 = label3.Text;
            string[] jackarr = new string[9];

            jackarr = text1.Split(' ');

            //code to get the amount betted by the jim
            string text2 = label4.Text;
            string[] jimarr = new string[9];

            jimarr = text2.Split(' ');


            if (x == Convert.ToInt32(bobarr[8]))
            {
                MessageBox.Show("Congratulations bob wins the race");
                int result = Convert.ToInt32(jackarr[5]) + Convert.ToInt32(jimarr[5]);
                if (boblist.Count > 0)
                {
                    int bobamount = Convert.ToInt32(boblist[boblist.Count - 1]);
                    int result1 = bobamount + result;
                    MessageBox.Show("Amount credited to bobs side  " + result);
                    MessageBox.Show("Total Amount  " + result1);
                    boblist.Add(result1);
                }
                int jackreduction = Convert.ToInt32(jacklist.Last()) - Convert.ToInt32(jackarr[5]);
                MessageBox.Show("Amount deducted from Jack account  " + Convert.ToInt32(jackarr[5]));
                MessageBox.Show("Amount remains in Jack account  " + jackreduction);
                jacklist.Add(jackreduction);
                int jimreduction = Convert.ToInt32(jimlist.Last()) - Convert.ToInt32(jimarr[5]);
                MessageBox.Show("Amount deducted from jim account  " + Convert.ToInt32(jimarr[5]));
                MessageBox.Show("Amount remains in Jack account  " + jimreduction);
                jimlist.Add(jimreduction);
                if (Convert.ToInt32(jacklist.Last()) <= 0)
                {
                    radioButton2.Enabled = false;
                    label3.Text = "you are busted";


                }
                if (Convert.ToInt32(jimlist.Last()) <= 0)
                {
                    radioButton1.Enabled = false;
                    label2.Text = "You are busted";

                }
            }
            // jim function
            if (x == Convert.ToInt32(jimarr[8]))
            {
                MessageBox.Show("Congratulations Jim wins the race");
                int result = Convert.ToInt32(jackarr[5]) + Convert.ToInt32(bobarr[5]);
                if (jimlist.Count > 0)
                {
                    int jimamount = Convert.ToInt32(jimlist[jimlist.Count - 1]);
                    int result1 = jimamount + result;
                    MessageBox.Show("Amount credited to jim side " + result);
                    MessageBox.Show("Total Amount " + result1);
                    jimlist.Add(result1);
                }
                int jackreduction = Convert.ToInt32(jacklist.Last()) - Convert.ToInt32(jackarr[5]);
                MessageBox.Show("Amount deducted from Jack account " + Convert.ToInt32(jackarr[5]));
                MessageBox.Show("Amound remains in Jack account " + jackreduction);
                jacklist.Add(jackreduction);
                int bobreduction = Convert.ToInt32(boblist.Last()) - Convert.ToInt32(bobarr[5]);
                MessageBox.Show("Amount deducted from bob account " + Convert.ToInt32(bobarr[5]));
                MessageBox.Show("Amound remains in Bob account " + bobreduction);
                boblist.Add(bobreduction);
                if (Convert.ToInt32(jacklist.Last()) <= 0)
                {
                    radioButton3.Enabled = false;
                    label4.Text = "you are busted";


                }
                if (Convert.ToInt32(boblist.Last()) <= 0)
                {
                    radioButton1.Enabled = false;
                    label2.Text = "you are busted";


                }






                /*objector.bobupdateData(result1);
                int mscore = Convert.ToInt32(objector.Selectdata(2));
                int mscore1 = mscore - Convert.ToInt32(jackarr[5]);
                objector.jackupdateData(mscore1);
                int jascore = Convert.ToInt32(objector.Selectdata(3));
                int jascore1 = jascore - Convert.ToInt32(jimarr[5]);
                objector.jimupdateData(jascore1);*/
            }
            /* else
             {
                 radioButton1.Enabled = false;
                 label2.Text = "You are busted";
             }*/
            if (x == Convert.ToInt32(jackarr[8]))
            {
                MessageBox.Show("Congratulations jack wins the race");
                int jackresult = Convert.ToInt32(bobarr[5]) + Convert.ToInt32(jimarr[5]);


                if (jacklist.Count > 0)
                {
                    int jackamount = Convert.ToInt32(jacklist[jacklist.Count - 1]);
                    int result1 = jackamount + jackresult;
                    MessageBox.Show("Amount credited to Jack side " + jackresult);
                    MessageBox.Show("Total Amount  " + result1);
                    jacklist.Add(result1);
                }
                int jimreduction = Convert.ToInt32(jimlist.Last()) - Convert.ToInt32(jimarr[5]);
                MessageBox.Show("Amount deducted from Jim account  " + Convert.ToInt32(jimarr[5]));
                MessageBox.Show("Amound remains in Jim account  " + jimreduction);
                jimlist.Add(jimreduction);
                int bobreduction = Convert.ToInt32(boblist.Last()) - Convert.ToInt32(bobarr[5]);
                MessageBox.Show("Amount deducted from bob account  " + Convert.ToInt32(bobarr[5]));
                MessageBox.Show("Amound remains in Bob account  " + bobreduction);
                boblist.Add(bobreduction);
                if (Convert.ToInt32(jimlist.Last()) <= 0)
                {
                    radioButton2.Enabled = false;
                    label3.Text = "you are busted";


                }
                if (Convert.ToInt32(boblist.Last()) <= 0)
                {
                    radioButton1.Enabled = false;
                    label2.Text = "you are busted";


                }

                /*objector.jackupdateData(jackresult1);
                int mscore = Convert.ToInt32(objector.Selectdata(1));
                int mscore1 = mscore - Convert.ToInt32(bobarr[5]);
                objector.bobupdateData(mscore1);
                int jascore = Convert.ToInt32(objector.Selectdata(3));
                int jascore1 = jascore - Convert.ToInt32(jimarr[5]);
                objector.jimupdateData(jascore1);*/
            }
            /*else
            {
                radioButton2.Enabled = false;
                label3.Text = "you are busted";
            }/*
            if (x == Convert.ToInt32(jimarr[8]))
            {
                MessageBox.Show("Congratulations jim wins the race");
                int jimresult = Convert.ToInt32(jackarr[5]) + Convert.ToInt32(bobarr[5]);
                int jimresult1 = Convert.ToInt32(jimarr[5]) + jimresult;
                MessageBox.Show("Amount credited to Jim side" + jimresult);
                MessageBox.Show("Total Amount" + jimresult1);
                objector.jimupdateData(jimresult1);
                int mscore = Convert.ToInt32(objector.Selectdata(1));
                int mscore1 = mscore - Convert.ToInt32(bobarr[5]);
                objector.bobupdateData(mscore1);
                int jascore = Convert.ToInt32(objector.Selectdata(2));
                int jascore1 = jascore - Convert.ToInt32(jackarr[5]);
                objector.jackupdateData(jascore1);
            }
            else
            {
                radioButton3.Enabled = false;
                label4.Text = "You are Busted";
            }*/

        }
    }
            
}
public class players:Form
{
  
    
    public int RandomGenerator()
    {
        Random r = new Random();
        int Genrand = r.Next(1,5);
        return Genrand;
    }
    public string Selectdata(int value)
    {
        string connection = "server=localhost;username=root;password=;database=customer3";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        //MessageBox.Show("database connected");
        string selectquery = "SELECT Amount FROM bikebettinggame WHERE id='" + value + "' ";
        MySqlCommand command = new MySqlCommand(selectquery, conn);
        MySqlDataReader reader = command.ExecuteReader();
        int amt = 0;
        string strresult = string.Empty;
        while (reader.Read())
        {
            strresult += reader.GetString(0);
        }
        string[] strArray = strresult.Split(' ');
        //MessageBox.Show("The value is" + strArray[0]);
        return strArray[0];

        /*string name = "Tom";
        string updatequery = "update bettinggametable set Amount = '" + Convert.ToInt32(amount) + "' where Name ='" + name + "' ";
        MySqlCommand command = new MySqlCommand(updatequery, conn);
        MySqlDataReader myreader;
        myreader = command.ExecuteReader();
        //MessageBox.Show("Data updated successfully");
        conn.Close();*/


    }
    public void bobupdateData(int value)
    {
        string connection = "server=localhost;username=root;password=;database=players";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
       
        string selectquery = "update bettingplayers set Amount='" + value + "' WHERE id='" + 1 + "' ";
        MySqlCommand command = new MySqlCommand(selectquery, conn);
        MySqlDataReader reader = command.ExecuteReader();
       

    }
    public void jackupdateData(int value)
    {
        string connection = "server=localhost;username=root;password=;database=players";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        // MessageBox.Show("database connected");
        string selectquery = "update bettingplayers set Amount='" + value + "' WHERE id='" + 2 + "' ";
        MySqlCommand command = new MySqlCommand(selectquery, conn);
        MySqlDataReader reader = command.ExecuteReader();
        //MessageBox.Show("Database updated successfully");

    }
    public void jimupdateData(int value)
    {
        string connection = "server=localhost;username=root;password=;database=players";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        //MessageBox.Show("database connected");
        string selectquery = "update bettingplayers set Amount='" + value + "' WHERE id='" + 3 + "' ";
        MySqlCommand command = new MySqlCommand(selectquery, conn);
        MySqlDataReader reader = command.ExecuteReader();
        //MessageBox.Show("Database updated successfully");

    }
    public void otherupdate()//THIS FUNCTION WILL RESET ALL THE AMOUNT TO PREVIOUS ONES
    {
        string connection = "server=localhost;username=root;password=;database=customer3";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        //MessageBox.Show("database connected");
        string selectquery = "UPDATE bikebettinggame SET Amount='" + 45 + "'  ";
        //string selectquery1 = "UPDATE bikebettinggame set Amount='" + 45 + "' WHERE id='" + 2 + "' ";
        //string selectquery2 = "update bikebettinggame set Amount='" + 45 + "'  WHERE id='" + 3 + "' ";

        MySqlCommand command = new MySqlCommand(selectquery, conn);
        //MySqlCommand command1 = new MySqlCommand(selectquery1, conn);
        //MySqlCommand command2 = new MySqlCommand(selectquery2, conn);

        MySqlDataReader reader1 = command.ExecuteReader();
        //MySqlDataReader reader2 = command1.ExecuteReader();
        // MySqlDataReader reader3 = command2.ExecuteReader();
        //MessageBox.Show("Database updated successfully");

    }


}
