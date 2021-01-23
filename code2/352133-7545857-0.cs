    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RegisterKeyDownHandlers(this);
        }
        private void RegisterKeyDownHandlers(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                ctl.KeyDown += KeyDownFired;
                RegisterKeyDownHandlers(ctl);
            }
        }
        private void KeyDownFired(object sender, EventArgs e)
        {
            MessageBox.Show("KeyDown fired for " + sender);
        }
    }
