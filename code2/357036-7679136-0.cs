    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Move +=new EventHandler(Form1_Move);
        }
        private void Form1_Move(object sender, System.EventArgs e)
        {
            this.Text = "Form screen position = " + this.Location.ToString();
        }
    }
