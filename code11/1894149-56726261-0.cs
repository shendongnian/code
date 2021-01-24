    public partial class CLOTHES : Form
    {
        public static int cost = 0;
        public static string name = "";
        public static string size = "";
        public static string NAME = "";
        public static string SIZE = "";
        public static int total = 0;
        List<string[]> data = new List<string[]>();
        public CLOTHES()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    SIZE = "small";
                    label1.Text = "T-SHIRT";
                    cost = 300;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    SIZE = "MEDIUM";
                    label1.Text = "T-SHIRT";
                    cost = 400;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    SIZE = "LARGE";
                    label1.Text = "T-SHIRT";
                    cost = 500;
                }
                name = label1.Text;
                size = comboBox1.SelectedIndex.ToString();               
                nextform(cost, size, name);
                string[] row = { "" + name, "" + size, "" + total };
                data.Add(row);
                
            }
        }
        void nextform(int cost, string size, string name)
        {
            total = cost;
            NAME = name;
            size = SIZE;
            MessageBox.Show("total " + total);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cart f5 = new cart();
            f5.populatedatagridview(data);
            f5.ShowDialog();
        }
    }
