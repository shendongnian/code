    public partial class MyUserControl : UserControl
    {
        // This property will be visible in your usercontrols property window in the designer
        public DataGridViewColumnCollection Columns
        {
            get { return dataGridView1.Columns; }
        }
        public MyUserControl()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;          
        }
    }
