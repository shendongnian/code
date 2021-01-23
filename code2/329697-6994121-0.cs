    using (var myentity= new MyEntities())
    {
        myentity.AttachTo("Companies", company);
        ObjectStateEntry entry = myentity.ObjectStateManager.GetObjectStateEntry(myentity);
        entry.SetModifiedProperty("CompanyName"); 
        myentity.SaveChanges();
    }
