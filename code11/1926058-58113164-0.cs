     public partial class UserControl1 : UserControl
            {
                public UserControl1()
                {
                    InitializeComponent();
                }
                private void button1_Click(object sender, EventArgs e)
                {
                    textBox1.Text = "1";
        
                    //The textbox text is not updated!
                }
            }
