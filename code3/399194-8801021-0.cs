    try
    {
    var b = db.Table.FirstOrDefault();
    }
    catch(Exception e)
    {
    ShowMessageBox(e.Message);
    }
