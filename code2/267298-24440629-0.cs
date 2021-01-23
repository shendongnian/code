    public static void OpenWebsite(string name)
    {
        DirectoryEntry Services = new DirectoryEntry("IIS://localhost/W3SVC");
        IEnumerator ie = Services.Children.GetEnumerator();
        DirectoryEntry Server = null;
        string nombre = "";
    
        while (ie.MoveNext())
        {
            Server = (DirectoryEntry)ie.Current;
            if (Server.SchemaClassName == IIsWebServer)
            {
                nombre = Server.Properties["ServerComment"][0].ToString();
                if (nombre == name)
                {
                    break;                
                }
            }
        }
    
        Console.Write(nombre); 
    } 
