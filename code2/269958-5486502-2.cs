    public partial class Form1 : Form
    {
        SqlConnection _cn;
        SqlCommand _cmd;
    
        const string ConnString = "Enter your connection string here";
        readonly string _insertQuery;
        const string UsernameParm = "@username";
    
        public Form1()
        {
            InitializeComponent(); 
            _cn = new SqlConnection(ConnString);
    
            _cmd = new SqlCommand(InsertQuery, _cn);        
            _cmd.Parameters.Add(UsernameParm, SqlDbType.VarChar);
    
            _insertQuery = String.Format("INSERT INTO checkmultiuser(username) VALUES ({0})",
                                         UsernameParm);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {        
            _cmd.Parameters[UsernameParm].Value = textBox1.Text;
    
            try
            {
                _cn.Open();
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex) // probably best to catch specific exceptions
            {
                // handle it
            }
            finally
            {
                _cn.Close();
            }
        }
    }
