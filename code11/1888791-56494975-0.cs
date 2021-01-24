    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.OleDb;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //here is a sample code which reads an Excel file Sheet1 which has 2 columns
                //And inserts the same into an access table
                //Change the file names, sheet name, table names and column names as per your requirements
                //File Names, replae with your file names
                string fileNameExcel = @"C:\your_path_here\Book1.xls";
                string fileNameAccess = @"C:\your_path_here\Database1.mdb";
    
                //Connection string for Excel
                string connectionStringExcel =
                    string.Format("Data Source= {0};Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;", fileNameExcel);
                //Connection string for Access
    
                string ConnectionStringAccess =
                    string.Format("Data Source= {0}; Provider=Microsoft.Jet.OLEDB.4.0; Persist security Info = false", fileNameAccess);
    
                //Connection object for Excel
                OleDbConnection connExcel = new OleDbConnection(connectionStringExcel);
                //Connection object for Access
                OleDbConnection connAccess = new OleDbConnection(ConnectionStringAccess);
                //Command object for Excel
                OleDbCommand cmdExcel = connExcel.CreateCommand();
                cmdExcel.CommandType = CommandType.Text;
                cmdExcel.CommandText = "SELECT * FROM [Sheet1$]";
    
                //Command object for Access
    
                OleDbCommand cmdAccess = connAccess.CreateCommand();
                cmdAccess.CommandType = CommandType.Text;
                cmdAccess.CommandText = "INSERT INTO Table1 (Column1, Column2) VALUES(@column1, @column2)";
                //Add parameter to Access command object
                OleDbParameter param1 = new OleDbParameter("@column1", OleDbType.VarChar);
                cmdAccess.Parameters.Add(param1);
                OleDbParameter param2 = new OleDbParameter("@column2", OleDbType.VarChar);
                cmdAccess.Parameters.Add(param2);
                //Open connections
                connExcel.Open();
                connAccess.Open();
                //Read Excel
                OleDbDataReader drExcel = cmdExcel.ExecuteReader();
    
                while (drExcel.Read())
                {
                    //Assign values to access command parameters
                    param1.Value = drExcel[0].ToString();
                    param2.Value = drExcel[1].ToString();
                    //Insert values in access
                    cmdAccess.ExecuteNonQuery();
                }
    
                //close connections
                connAccess.Close();
                connExcel.Close();
    
            }
        }
    }
