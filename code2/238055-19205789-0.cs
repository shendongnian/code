     public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            
            //Step 1) 
            //Display the form passing parameter(s) via overloading 
            //the ShowDialog() method. 
            //In this example the parameter is the 'txtBoxForm1' on Form1.
            // f2.ShowDialog(); is replaced by
            f2.ShowDialog(ref txtBoxForm1); 
            
        }
    }
 
