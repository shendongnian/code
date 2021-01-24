    public partial class Form1 : Form
    {
        private bool isUpdated = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void listBox1_SelectedIndexChanged(Object  sender, EventArgs e)
        {
            if (this.isUpdated)
            {
                this.textBox1.Text = ((ListBox)sender).SelectedItem.ToString();
                this.isUpdated = false;
            }
            
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.isUpdated = true;
        }
    }
