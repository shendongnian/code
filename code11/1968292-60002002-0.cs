         public partial class Form1 : Form
            {
                //MS SQL Connection server
                public string connectionString;
                public SqlConnection MSSQL;
        
                //MySQL server Connectivity
                public string connStr;
                public MySqlConnection conn;
                private void Start_Click(object sender, EventArgs e)
                {
                try
                {
                    //Connection Process of MS SQL Server
                    connectionString = @"Data Source='your source name';Initial Catalog='database name';User ID='username';Password='password'";
                    MSSQL = new SqlConnection(connectionString);
                    //opening connection of MS SQL Server
                    MSSQL.Open();
                    MessageBox.Show("Connection Open of MS SQL !");
    
    
                    //Connection Process of MySQL Server
                    connStr = "server='server name';user='username';database='database name';port='port';password='password'";
                    conn = new MySqlConnection(connStr);
                    //opening connection of MySQL Server
                    conn.Open();
                    MessageBox.Show("Connection open of MySQL!");
                }
                catch (Exception ex)
                {
                     Console.WriteLine(ex.ToString());
                }
            }
