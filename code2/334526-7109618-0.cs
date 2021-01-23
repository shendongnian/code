        public partial class Form1 : Form
        {
            private bool hasError;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void OkBtn_Click(object sender, EventArgs e)
            {
                errorProvider1.Clear(); hasError=false;
                if (ValidateTxt.Text.Length == 0)
                {
                    errorProvider1.SetError(ValidateTxt, "must have a value");
                    hasError=true;
                }
                if (!hasError)
                {
                    //Do what you want to do and close your application
                    Close();
                }
                    
            }
    
            private void CancelBtn_Click(object sender, EventArgs e)
            {
                Close();
            }
        }
