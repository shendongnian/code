        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool isActive = false;
        private FormWindowState previousstate;
        private void Form1_Load(object sender, EventArgs e)
        {
            previousstate = this.WindowState;
            //Got Focus Anonymous Delegate handles focus on the textbox
            //if the Form currently is Activated
            this.Resize += delegate(object resizesender, EventArgs resizee)
            {
                //if (previousstate == FormWindowState.Minimized)
                // {
                    txtGetFocus.Focus();
                    this.Refresh();
                // }
                previousstate = this.WindowState;
            };
            this.Activated += delegate(object activatedsender, EventArgs activatede)
            {
                isActive = true;
            };
            this.Deactivate += delegate(object deactivatesender, EventArgs deactivatee)
            {
                isActive = false;
            };
        }
    }
