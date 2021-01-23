    class YourFormClass : Form, IYourForm
    {
        // lots of other code here
    
        public string FirstName
        {
            get { return firstNameTextBox.Text; }
            set { firstNameTextBox.Text = value; }
        }
    }
