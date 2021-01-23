    public partial class ValidatingTextBox: TextBox
    {
        public ValidatingTextBox()
        {
            InitializeComponent();
        }
        protected override void OnValidating(CancelEventArgs e)
        {
            bool bTest = txtRegExStringIsValid(this.Text.ToString());
            ToolTip tip = new ToolTip();
            if (bTest == false)
            {
                tip.Show("Only A-I", this, 2000);
                this.Text = " ";
            } 
        }
        private bool txtRegExStringIsValid(string textToValidate) 
        { 
           // Exactly the same validation logic as in the same method on the form
        }
    }
