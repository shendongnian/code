        protected TestIssue myIssue;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Only called on first load, not when button clicked
                myIssue = new TestIssue(); 
            }
        }
        
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            myIssue.Entry = "NullReferenceException here!";
        }
    }
