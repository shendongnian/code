    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        //Step 2)
        //Receiving and returning parameter(s) via the overloaded ShowDialog() method.
        //This saves the need to have Properties and or fields associated
        //to parameters when overloading the above Form() constructor instead.
        public void ShowDialog(ref TextBox txtBoxForm1)
        {
            //Assign received parameter(s) to local context
            txtBoxForm2.Text = txtBoxForm1.Text;
            
            this.ShowDialog(); //Display and activate this form (Form2)
 
            //Return parameter(s)
            txtBoxForm1.Text = txtBoxForm2.Text;
        }
    }
