public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void SetActive(Button active)
        {
            foreach(var btn in new[] {button1, button2, button3, button4, button5})
            {
               btn.BackColor = btn == active ? Color.Green : Color.Lavender;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetActive(button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SetActive(button2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SetActive(button3);
        }
    }
}
