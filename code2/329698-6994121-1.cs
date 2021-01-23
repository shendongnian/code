    using (var myentity= new MyEntities())
    {
        myentity.AttachTo("Companies", company);
        ObjectStateEntry entry = myentity.ObjectStateManager.GetObjectStateEntry(company);
        entry.SetModifiedProperty("CompanyName"); 
        myentity.SaveChanges();
    }
