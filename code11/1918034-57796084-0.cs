    public partial class Form1 : Form
    {
        private Screen _actualScreen;
        public Form1()
        {
            InitializeComponent();
            _actualScreen = Screen.FromControl(this);
            this.ResizeEnd += Form1_ResizeEnd;
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if(_actualScreen != Screen.FromControl(this))
            {
                //Your treatment
            }
        }
    }
