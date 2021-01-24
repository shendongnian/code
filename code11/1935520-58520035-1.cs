    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            obj.TextEvent += obj_TextEvent;
        }
        void obj_TextEvent(object sender, EventArgs e)
        {
            label1.Text = sender.ToString();
        }
    }
