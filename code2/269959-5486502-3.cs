    public partial class Form1 : Form
    {
        const string ConnString = "Enter your connection string here";
        readonly string _insertQuery;
        const string UsernameParm = "@username";
    
        public Form1()
        {
            InitializeComponent();             
    
            _insertQuery = String.Format("INSERT INTO checkmultiuser(username) VALUES ({0})",
                                         UsernameParm);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {  
            using (var cn = new SqlConnection(ConnString))
            {
                using (var cmd = new SqlCommand(InsertQuery, cn))
                {
                    cmd.Parameters.Add(UsernameParm, SqlDbType.VarChar);
                    cmd.Parameters[UsernameParm].Value = textBox1.Text;
                    
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
