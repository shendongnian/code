    class MyForm
    {
        protected Panel pnlTaskAssignation;  //Add this yourself
        public void MyForm_Load(object sender, EventArgs e)
        {
            var panel = new Panel()
            {
                AutoSize = true,
                Height = 45,
                BackColor = Color.WhiteSmoke,
                Name =  "pnlTaskAssignation"
            }
            pnlTaskAssignation = panel; //Save the reference here
        };
