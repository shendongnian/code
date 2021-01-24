    using BusinessManager;
    using DataAccess;
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace RestuarnetManagementSystem.Softangles
    {
        public partial class POS : Form
        {
            Manager manager = new Manager();
            DataClass dataClass = new DataClass();
            Categories categories = new Categories();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ButtonData bd = new ButtonData();
            MenuItems menuItems = new MenuItems();
            int btnName = 0;
            public POS()
            {
                InitializeComponent();
            }
    
            private void tabPage1_Click(object sender, EventArgs e)
            {
    
            }
    
            public void panel7_Paint(object sender, PaintEventArgs e)
            {
                //ds.Tables[0].Rows[i].ItemArray[0].ToString()
    
                //dt = manager.DeployButtonCategoryText(categories);
                dt = manager.DeployButtonCategoryText(categories);
                var count = dt.Rows.Count;
                //int btnName = 0;
    
                int PosY = 5;
                int rowCount = -1;
                for (int i = 0; i < count; i++)
                {
                    //btnName++;
                    rowCount++;
                    btnName++;
                    foreach (DataRow row in dt.Rows)
                    {
                        categories.btnText = dt.Rows[rowCount].Field<string>(0);
                        //categories.btnText = row.Field<string>("Categories", DataRowVersion.Original);
                    }
                    //string btnText = count.ToString();
                    Button btn1 = new Button();
                    btn1.Enabled = true;
                    btn1.Text = categories.btnText;
                    categories.btnText = btn1.Text;
                    btn1.BackColor = Color.Navy;
                    btn1.ForeColor = Color.White;
                    btn1.Width = 150;
                    btn1.Height = 50;
                    btn1.Name = "btn1"+btnName;
    
    
                    btn1.Location = new Point(-2, PosY);
                    btn1.Font = new Font("Georgia", 12);
                    btn1.Click += new EventHandler(btn1_Click);
                    pnlCategories.Controls.Add(btn1);
                    PosY += 55;
    
                    //var newvalue =  ds.Tables[0].Rows[1].ItemArray[0].ToString();
                }
    
    
    
    
            }
    
            private void POS_Load(object sender, EventArgs e)
            {
    
    
    
    
    
            }
    
            private void btn1_Click(object sender, EventArgs e)
            {
                pnlMenuItems.Controls.Clear();
                Button btn = sender as Button;
                 menuItems.FindMenuItems = btn.Text;
                  dt =  manager.GetMenuItems(menuItems);
                 int rowCount = dt.Rows.Count;
                int counter = -1;
                if(dt.Rows.Count>0)
                {
                  
                    int PosX = 100;
                    for (int i = 0; i < rowCount; i++)
                    {
                        btnName++;
                        counter++;
                        foreach (DataRow row in dt.Rows)
                        {
                            menuItems.MenuText = dt.Rows[counter].Field<string>(0);
                        }
    
                        Button button = new Button();
                        button.Enabled = true;
                        button.Text = menuItems.MenuText;
                        button.BackColor = Color.Navy;
                        button.ForeColor = Color.White;
                        button.Font = new Font("Georgia", 12);
                        button.Location = new Point(PosX, 10);
                        button.Width = 150;
                        button.Height = 50;
                        button.Name = "button" + btnName;
                        button.Click += new EventHandler(button_Click);
                        pnlMenuItems.Controls.Add(button);
                        PosX += 150;
                    }
                }
                else
                {
                    MessageBox.Show("Failed!");
                }
                //dt = manager.GetMenuItems(menuItems);
                //int count = dt.Rows.Count;
                ////int btnName = 0;
    
                //int PosX = 160;
                //int rowCount = -1;
                //for (int i = 0; i < count; i++)
                //{
                //    //btnName++;
                //    rowCount++;
                //    foreach (DataRow row in dt.Rows)
                //    {
                //       menuItems.MenuText = dt.Rows[rowCount].Field<string>(0);
    
                //    }
                //    //string btnText = count.ToString();
                //    Button btn2 = new Button();
                //    btn2.Enabled = true;
                //    btn2.Text = menuItems.MenuText;
    
                //    btn2.BackColor = Color.Navy;
                //    btn2.ForeColor = Color.White;
                //    btn2.Width = 150;
                //    btn2.Height = 50;
                //    btn2.Name = "btn2";
    
    
                //    btn2.Location = new Point(PosX, 10);
                //    btn2.Font = new Font("Georgia", 12);
                //    btn2.Click += new EventHandler(btn2_Click);
                //    pnlCategories.Controls.Add(btn2);
                //    PosX += 150;
    
                //    //var newvalue =  ds.Tables[0].Rows[1].ItemArray[0].ToString();    
    
            }
    
            private void button_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Test");
            }
    
    
        }
    
    
    }
