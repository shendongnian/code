    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }
        
        public void UpdateCombo(List<String> newName)
        {
            comboBox1.Items.Clear();
            foreach (string fname in newName)
            {
                comboBox1.Items.Add(fname);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
