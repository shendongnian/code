    public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
                string connectionstring = @"";
                MySqlConnection connection = new MySqlConnection(connectionstring);
                connection.Open();
                string sql = string.Format("select * from Teacher where Name='{0}'",textBox1.Text);
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet set = new DataSet();
                adapter.Fill(set);
                dataGridView1.DataSource = set.Tables[0];
            }
    
            public TextBox tb
            {
                get { return textBox1; }
                set { textBox1 = value; }
    
            }
        }
