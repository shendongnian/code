      public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string connectionstring = @"connectionstring";
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "select * from Student";
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dataSet);
                connection.Close();
                dataGridView1.DataSource = dataSet.Tables[0];
            }
        }
