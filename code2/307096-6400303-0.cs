    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ComboBox b1 = new ComboBox();
            b1.BackColor = Color.Blue;
            flp.Controls.Add(b1);
            b1.Text = b1.TabIndex.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (flp.Controls.Count > 0)
            {
                flp.Controls.RemoveAt(flp.Controls.Count - 1);
            }
        }
        
       
    }
}
