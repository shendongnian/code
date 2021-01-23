    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                this.BringFormToFront();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                Hide();
            }
        }
