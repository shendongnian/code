      public partial class Form1 : Form
        {
            // Control the buttons.
            List<Button> buttons = new List<Button>();
    
            public Form1()
            {
                InitializeComponent();
        
                buttons.Add(this.button1);
                buttons.Add(this.button2);
                buttons.Add(this.button3);
                buttons.Add(this.button4);
            }
        
            private void Button_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
                foreach (var b in buttons)
                {
                    if (button.Text.Equals(b.Text))
                    {
                        b.Enabled = false;
                    }
                    else
                    {
                        b.Enabled = true;
                    }
                }
            }
        }
