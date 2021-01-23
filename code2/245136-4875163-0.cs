    protected void uxEntityDataSourceCreateJob_Inserted(object sender, EntityDataSourceChangedEventArgs e)
    {
        using (var context = new YourEFObjectContext())
        {
            Guid myUserListSelected = new Guid(uxListUsers.SelectedValue);
            CmsJob myJob = (CmsJob)e.Entity; // My new Jobid
            aspnet_Users myUser = context.aspnet_Users.Single(u => u.UserId == myUserListSelected);
            myUser.CmsJobs.Add(myJob);
            context.SaveChanges();
        }
    }
