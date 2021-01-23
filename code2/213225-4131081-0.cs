    Organization org=new Organization();
    User user = new User();
    
    using (var ctx = new YourContext())
    {
       ctx.Organizations.InsertOnSubmit(org);
       ctx.SubmitChanges();
       user.Organization = org;    
    }
    
    using (var newCtx = new YourContext())
    {
       // code to persist user 
    }
