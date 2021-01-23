    protected void Delete_LinkButton_Click(object sender, EventArgs e)
    {
        string userName = ((LinkButton)sender).CommandArgument.ToString();
        Membership.DeleteUser(UserName);
        JobPostDataContext db = new JobPostDataContext();
        
         foreach (var item in db.UserDetails.Where(u => u.UserName == userName))
              db.UserDetails.DeleteOnSubmit(Item);
        db.SubmitChanges();
    }
