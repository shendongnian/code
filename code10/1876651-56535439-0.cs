    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel; 
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    System.Data.OleDb.OleDbConnection MyConnection ;
                    System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                    string sql = null;
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\csharp.net-informations.xls';Extended Properties=Excel 8.0;");
                    MyConnection.Open();
                    myCommand.Connection = MyConnection;
                    sql = "Insert into [Sheet1$] (id,name) values('5','e')";
                    myCommand.CommandText = sql;
                    myCommand.ExecuteNonQuery();
                    MyConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show (ex.ToString());
                }
            }
       }
    }
