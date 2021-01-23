    public partial class Form1 : Form
    {
        BindingSource bs;
        public Form1()
        {
            InitializeComponent();
            bs = new BindingSource();
            MyBindingList<BackingObject> backing_objects = new MyBindingList<BackingObject>();
            backing_objects.Add(new BackingObject{ PrimaryKey = 1, Name  = "Fred", Hidden = "Fred 1"});
            bs.DataSource = backing_objects;
            dataGridView1.DataSource = bs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int index = bs.Find("PrimaryKey", 5);
            bs.Position = index;
            dataGridView1.FirstDisplayedScrollingRowIndex = index - 1;            
        }
    }
