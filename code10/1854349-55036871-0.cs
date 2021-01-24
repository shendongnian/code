    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.Items.Add(new ListViewItem("File path"));
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            var itemvalue = listView1.Items[0].Text;
        }
    }
