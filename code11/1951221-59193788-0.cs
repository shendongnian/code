     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("button1 was clicked");
            }
       
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    
            {
                KeyEventArgs e = new KeyEventArgs(keyData);
                if (e.KeyCode == Keys.F1)
    
                {
                    button1_Click("", e);
                }
                return base.ProcessCmdKey(ref msg, keyData);
    
            }
        }
