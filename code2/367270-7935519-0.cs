     public partial class Form1 : Form
        {
            MouseButtons _buttons;
    
            public Form1()
            {
                InitializeComponent();
    
            }
    
            private void button1_MouseMove(object sender, MouseEventArgs e)
            {
                if (_buttons != System.Windows.Forms.MouseButtons.None)
                {
                    this.Text = _buttons.ToString();
                }
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                _buttons = Control.MouseButtons;
            }
        }
