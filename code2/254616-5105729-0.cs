    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    // Instantiate a new instance of Form1.
        //    Form1 f1 = new Form1();
        //    f1.Text = "zzzzzzz";
     
        //}
    }
    class MainApplication
    {
        public static void Main()
        {
            // Instantiate a new instance of Form1.
            Form1 f1 = new Form1();
            // Display a messagebox. This shows the application 
            // is running, yet there is nothing shown to the user. 
            // This is the point at which you customize your form.
            System.Windows.Forms.MessageBox.Show("The application "
               + "is running now, but no forms have been shown.");
            // Customize the form.
            f1.Text = "Running Form";
            // Show the instance of the form modally.
            f1.ShowDialog();
        }
    }
}
