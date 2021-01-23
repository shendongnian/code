    // instantiate the datacontext object using the connection string
    var db = new dbDataContext("myConnectionString");
    
    // retrieve the record to update
    var record = (from r in db.Section where r.Name == "thing" select r).Single();
        
    record.Content = "Content";
    
    try
    {
    // try to update the database
    db.SubmitChanges();
    MessageBox.Show("Success!");
    }
    catch
    {
    // Darn!  Didn't work...
    MessageBox.Show("Ooops!");
    }
