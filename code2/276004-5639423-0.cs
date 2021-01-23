    public void Save()
    {
        Northwnd db = new Northwnd(@"c:\northwnd.mdf");
        // Make changes here. 
        try
        {
            db.SubmitChanges();
        }
        catch (Exception err)
        {
            //Log error
        }
    }
