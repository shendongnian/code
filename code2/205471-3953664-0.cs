    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    static void Main(string[] args)
    {
        // create instance of SMO Server object
        Server myServer = new Server("(local)");
        
        // create new instance of "Restore" object    
        Restore res = new Restore();
        res.Database = "SMO";  // your database name
     
        // define options       
        res.Action = RestoreActionType.Database;
        res.Devices.AddDevice(@"C:\SMOTest.bak", DeviceType.File);
        res.PercentCompleteNotification = 10;
        res.ReplaceDatabase = true;
        // define a callback method to show progress
        res.PercentComplete += new PercentCompleteEventHandler(res_PercentComplete);
        
        // execute the restore    
        res.SqlRestore(myServer);
     }
     // method to show restore progress
     static void res_PercentComplete(object sender, PercentCompleteEventArgs e)
     {
        // do something......
     }
