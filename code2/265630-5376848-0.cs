    public partial class Form1 : Form
    {
        private readonly BindingList<string> list = new BindingList<string> { "apple", "pear", "grape", "taco", "screwdriver" };
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = list;
            listBox2.DataSource = list;
        }
        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var tmp = list[0];
            list[0] = list[listBox1.SelectedIndex];
            list[listBox1.SelectedIndex] = tmp;
        }
    }
