    public partial class Form2 : Form
    {
        bool isMinimized;
        private Form2()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Enabled = true;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            MinimizeBox = Owner != null;
            if (Owner != null)
            {
                Owner.Enabled = false;
            }
        }
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                if (WindowState == FormWindowState.Minimized && Owner.WindowState != FormWindowState.Minimized)
                {
                    Owner.Enabled = true;
                    Owner.WindowState = FormWindowState.Minimized;
                    isMinimized = true;
                }
                else if (isMinimized && Owner.WindowState != FormWindowState.Minimized)
                {
                    Owner.Enabled = false;
                }
            }
        }
        public static void Show(Form owner, string message)
        {
            var form2 = new Form2();
            form2.label1.Text = message;
    
            if (owner != null)
                form2.Show(owner);
            else
                form2.ShowDialog();
        }
    }
