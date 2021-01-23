     public Form2(string str1,string str2)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("C", "C1");
            dataGridView1.Columns.Add("C","c2");
            dataGridView1.Rows.Add(str1, str2);
        }
