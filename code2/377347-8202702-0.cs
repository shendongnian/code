    DirectoryEntry w3svc = new DirectoryEntry("IIS://localhost/w3svc");
          
    foreach(DirectoryEntry de in w3svc.Children)
    {
       if(de.SchemaClassName == "IIsWebServer")
       {
           //It's a website.
       }          
    }
