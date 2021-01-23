    public static string PingHost(string args)  
            {  
                HttpWebResponse res = null;  
     
                try 
                {  
                    // Create a request to the passed URI.  
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(args);  
                    req.Credentials = CredentialCache.DefaultNetworkCredentials;  
     
                    // Get the response object.  
                    res = (HttpWebResponse)req.GetResponse();  
     
                    return "Service Up";  
                }  
                catch (Exception e)  
                {  
                    MessageBox.Show("Source : " + e.Source, "Exception Source", MessageBoxButtons.OK);  
                    MessageBox.Show("Message : " + e.Message, "Exception Message", MessageBoxButtons.OK);  
                    return "Host Unavailable";  
                }  
            } 
