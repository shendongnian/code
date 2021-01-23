      DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
            //you fill the table from database, I will show you my example (becuase I dont have dataBase)!
            table.Columns.Add("CategoryID", typeof(int));
            table.Columns.Add("CategoryName", typeof(string));
            table.Rows.Add(1, "name 1"); 
            table.Rows.Add(2, "name 2");
            table.Rows.Add(3, "name 3");
            listBox1.DataSource = new BindingSource(table, null);
            listBox1.DisplayMember = "CategoryName";
            listBox1.ValueMember = "CategoryID";
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                DataRowView data = listBox1.SelectedItem as DataRowView;
                int id = int.Parse(data["CategoryID"].ToString());
                string name = data["CategoryName"].ToString();
            }
        }
