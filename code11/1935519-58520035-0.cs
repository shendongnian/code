    public partial class Form2 : Form
    {
        public event EventHandler TextEvent;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (TextEvent != null)
            {
                TextEvent(label1.Text, null);
            }
        }
    }
