        protected TestIssue myIssue;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myIssue = new TestIssue(); // Only called on first load, not when button clicked
            }
        }
        
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            myIssue.Entry = "NullReferenceException here!";
        }
    }
