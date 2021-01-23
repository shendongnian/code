     string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("UserName" + ":" + "Password"));
     StringBuilder outputData = new StringBuilder();
     HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(RSSFeed);
     myHttpWebRequest.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
     myHttpWebRequest.Headers.Add("Authorization", "Basic " + credentials);
     HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
     Stream streamResponse = myHttpWebResponse.GetResponseStream();
 
