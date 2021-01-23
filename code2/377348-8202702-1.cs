    DirectoryEntry w3svc = new DirectoryEntry("IIS://" + this._serverName + "/w3svc");
          
    foreach(DirectoryEntry de in w3svc.Children)
    {
       if(de.SchemaClassName == "IIsWebServer")
       {
           var id = de.Name; //Name is the ID
           var displayName = de.Properties["ServerComment"].Value.ToString();
       }          
    }
