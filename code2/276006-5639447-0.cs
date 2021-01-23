    Northwnd db = new Northwnd(@"c:\northwnd.mdf");
    // Make changes here. 
    try
    {
        db.SubmitChanges();
    }
    catch (ChangeConflictException e)
    {
        Console.WriteLine(e.Message);
        // Make some adjustments.
        // ...
        // Try again.
        db.SubmitChanges();
    }
