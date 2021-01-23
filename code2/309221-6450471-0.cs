    using System.Net;
    using System.Windows.Forms;
    
    string url = "http://www.google.com";
    string result = null;
    
        WebClient client = new WebClient();
        result = client.DownloadString( url );
