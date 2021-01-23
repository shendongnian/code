    using System;
    using System.Windows.Forms;
    using System.Data.OleDb; 
    
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
    			string filename = "filename.xls";
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + @";Extended Properties=""Excel 8.0;HDR=1;IMEX=1""";
    			
    			string sql = "SELECT * FROM myRange1"; 
    
                using(var conn = new OleDbConnection(connString);
    			using(var cmd = new OleDbCommand(sql, conn);
    			{
    				conn.Open();
    				
                    Int32 myReturnScalar = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
