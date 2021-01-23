    using System;
    using System.Net;
    using System.IO;
    
    public static string Download (string uri)
    {
        WebClient client = new WebClient ();
    
        Stream data = client.OpenRead (uri);
        StreamReader reader = new StreamReader (data);
        string s = reader.ReadToEnd ();
        data.Close ();
        reader.Close ();
        return s;
    }
    
