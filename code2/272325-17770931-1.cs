    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); //set the only message pump to form1.
        }
    }
    public partial class Form1 : Form
    {
        public static Form1 Form1Instance;
        public Form1()
        {
            //Everyone eveywhere in the app show know me as Form1.Form1Instance
            Form1Instance = this;
            //Make sure I am kept hidden
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;
            InitializeComponent();
            
            //Open a managed form - the one the user sees..
            var form2 = new Form2();
            form2.Show();
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form3 = new Form3(); //create an instance of form 3
            Hide();             //hide me (form2)
            form3.Show();       //show form3
            Close();            //close me (form2), since form1 is the message loop - no problem.
        }
    }
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Form1Instance.Close(); //the user want to exit the app - let's close form1.
        }
    }
