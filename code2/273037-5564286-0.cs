    try
    {
        bool deletePermanently = true; //Set to false to move
    
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("C:\\Test");
        if (deletePermanently)
        {
            if (di.Exists)
                di.Delete(true);
        }
        else
        {
            if (di.Exists)
                di.MoveTo("C:\\$Recycle.Bin\\S-0-0-00-00000000-000000000-0000000000-000"); //Replace with your SID
        }
    }
    catch
    {
        Console.WriteLine("Error deleting directory"); //Add exception detail messages...
    }
