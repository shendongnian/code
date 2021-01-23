    private class DataBindingProjection
    {
        public string UserName { get; set; };
        public string Password { get; set; };
        public string Description { get; set; };
    }
    private void simpleButton1_Click(object sender, EventArgs e)
    {
        context = new WS_Entities();
        var query = from c in context.Users
                    where c.UserName == "James"
                    select new DataBindingProjection { UserName = c.UserName, Password = c.Password, Description = c.Description };
        var users = query.ToList();
        gridControl1.DataSource = users;
    }
    private void simpleButton2_Click(object sender, EventArgs e) 
    {
        // and here you have some code to map the properties back from the 
        // projection objects to your datacontext
        context.SaveChanges();
    }
