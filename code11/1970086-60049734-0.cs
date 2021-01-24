   public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> list = new List<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
           
            if (int.TryParse(textBox1.Text, out a) == false) 
            {
                MessageBox.Show("Please input again");
                textBox1.Clear();
            }
            else
            {
                a = Convert.ToInt32(textBox1.Text);
                list.Add(a);
                label1.Text = string.Format("Average is {0}", list.Average());
            }
        }
    }
}
