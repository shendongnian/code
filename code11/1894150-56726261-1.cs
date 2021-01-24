     public partial class cart : Form
    {
        public cart()
        {
            InitializeComponent();
        }
        public void populatedatagridview(List<string[]> data)
        {
            foreach (var item in data)
            {
                dataGridView1.Rows.Add(item);
            }
            
        }
    }
