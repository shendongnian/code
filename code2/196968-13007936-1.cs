     public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            public DialogResult ShowDialog(string mes)
            {
                this.textBox1.Text = mes;
                return base.ShowDialog();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
