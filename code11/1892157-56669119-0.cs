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
    using System.Collections;
    using System.Data.OleDb;
    using System.IO;
    using System.Configuration;
    
    namespace ControlDataBase
    {
        public partial class New_Tables : Form
        {
            public New_Tables()
            {
                InitializeComponent();
            }
            Form1 frm1 = (Form1)Application.OpenForms["Form1"];
    
            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void ImportData_Click(object sender, EventArgs e)
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xltx;*.xltm;*.xls;*.xlt;*.xls;*.xml;*.xml;*.xlam;*.xla;*.xlw;*.xlr;", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fi = new FileInfo(ofd.FileName);
                        string FileName1 = ofd.FileName;
    
                        string excel = fi.FullName;
    
                        if (ofd.FileName.EndsWith(".xlsx"))
                        {
                            StrConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=\"Excel 12.0;\"";
                        }
    
                        if (ofd.FileName.EndsWith(".xls"))
                        {
                            StrConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excel + ";Extended Properties=\"Excel 1.0;HDR=Yes;IMEX=1\"";
                        }
                        OleDbConnection oledbconn = new OleDbConnection(StrConn);
    
                        OleDbDataAdapter dta5 = new OleDbDataAdapter("SELECT * FROM [Order_status$]", oledbconn);
                        oledbconn.Open();
    
                        DataSet dsole5 = new DataSet();
                        dta5.Fill(dsole5, "Order_status$");
                        datagrdStatus_order.DataSource = dsole5.Tables["Order_status$"];
    
                        oledbconn.Close();
            string constring = "datasource = localhost; port = 3306; username = root; password = ";
            using (MySqlConnection con = new MySqlConnection(constring))
            {
    
    con.Open();
    foreach (DataGridViewRow row in datagrdStatus_order.Rows)
    {
            using (MySqlCommand cmd = new MySqlCommand("INSERT IGNORE INTO try1.order_status(ID_WORKER, ID_ORDER, ID_MODULE, ID_PROJECT, AMOUNT_OF_PRODUCTS, BEGIN_DATE, END_DATE) SELECT workers.ID_WORKER, orders.ID_ORDER, module.ID_MODULE, projects.ID, @AMOUNT_OF_PRODUCTS, @BEGIN_DATE, @END_DATE FROM try1.workers INNER JOIN try1.orders INNER JOIN try1.modules INNER JOIN try1.projects WHERE workers.FNAME = @FNAME AND workers.LNAME = @LNAME AND workers.ID_WORKER = @ID_WORKER AND orders.DESC_ORDER = @DESC_ORDER AND orders.ORDER_NUMBER = @ORDER_NUMBER AND modules.NAME = @MODULES_NAME AND projects.PROJECT_NAME = @PROJECT_NAME", con))
            {
                cmd.Parameters.AddWithValue("@ID_WORKER", row.Cells["ID_WORKER"].Value);
                cmd.Parameters.AddWithValue("@FNAME", row.Cells["FNAME"].Value);
                cmd.Parameters.AddWithValue("@LNAME", row.Cells["LNAME"].Value);
                cmd.Parameters.AddWithValue("@DESC_ORDER", row.Cells["DESC_ORDER"].Value);
                cmd.Parameters.AddWithValue("@ORDER_NUMBER", row.Cells["ORDER_NUMBER"].Value);
                cmd.Parameters.AddWithValue("@MODULES_NAME", row.Cells["NAME"].Value);
                cmd.Parameters.AddWithValue("@PROJECT_NAME", row.Cells["PROJECT_NAME"].Value);
                cmd.Parameters.AddWithValue("@AMOUNT_OF_PRODUCTS", row.Cells["AMOUNT_OF_PRODUCTS"].Value);
                cmd.Parameters.AddWithValue("@BEGIN_DATE", row.Cells["BEGIN_DATE"].Value);
                cmd.Parameters.AddWithValue("@END_DATE", row.Cells["END_DATE"].Value);
                
                cmd.ExecuteNonQuery();
                
            }
        }
    con.Close();
    }
                        connection.Close();
                        MessageBox.Show("The data are imported correctly");
    
                        loaddataalldatagridview();
                    }
                }
            }
    
            private void loaddataalldatagridview()
            {
                frm1.loaddata5();
            }
        }
    }
