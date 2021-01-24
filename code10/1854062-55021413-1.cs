    company c = db.companies.Find(id);
    try
    {
       c.GetType().GetProperty(field).SetValue(c, input, null);
    }
    catch (Exception ex)
    {
    }
    
    
    .....
    //Update model
