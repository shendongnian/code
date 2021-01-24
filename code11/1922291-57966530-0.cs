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
    
    namespace Firemax
    {
        public partial class Login : Form
        {
            MySqlConnection con = new MySqlConnection(@"Data Source=xyz.com;port=3333;Initial Catalog = test_db;User Id = fml;password=imscrewed");
            int i;
            public Login()
            {
                InitializeComponent();
                this.CenterToScreen();
            }
    
            private void BunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
            {
    
            }
    
            private void BunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
            {
                bunifuMaterialTextbox2.isPassword = true;
            }
    
            private void BunifuFlatButton1_Click(object sender, EventArgs e)
            {
                i = 0;
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from users where username='" + bunifuMaterialTextbox1.Text + "' and password='" + bunifuMaterialTextbox2.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
    
    			Home fm = new Home();
                if (i==0)
                {
                    bunifuCustomLabel3.Text = "You have entered either a wrong Username and/or Password";
    
                    fm.bunifuCustomLabel2.Text = "test";
                }
                else
                {
                    this.Hide();                
                    fm.Show();
                    fm.Location = this.Location;
                }
                con.Close();
    
            }
    
            private void BunifuMaterialTextbox1_OnValueChanged_1(object sender, EventArgs e)
            {
    
            }
    
            private void BunifuImageButton1_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
