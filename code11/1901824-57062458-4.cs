    public MyDataGridUserControl : UserControl
    {
        ...
        public List<MyData> Data {
            get { return (List<MyData>)dataGridView1.DataSource; }
            set { dataGridView1.DataSource = value }
        }
    }
