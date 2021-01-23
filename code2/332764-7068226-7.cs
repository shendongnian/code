    public partial class Form1 : Form
    {
        private Form2 f2;
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(Form1_Resize);
            // Initialize Form2 
            f2 = new Form2();
        }
        void Form1_Resize(object sender, System.EventArgs e)
        {
           // whenever I change the size of Form1, make sure 
           // Form2 has the same WindowState
           f2.WindowState = this.WindowState;
        }
        // This is your condition to either show or hide the form.
        //
        // Rather than a checkbox, have something that will respond to whatever 
        // condition you have set out - probably an event on another class.
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                f2.Show();
            }
            else
            {
                f2.Hide();
            }
        }
    }
