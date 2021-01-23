     public partial class Form2 : Form
     {
            public Form2()
            {
                InitializeComponent();
            }
    
            public bool ShowMoreActions = false;
            private void button1_Click(object sender, EventArgs e)
            {
                ShowMoreActions = true;
                this.Close();
            }
    
                
            private void button2_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
