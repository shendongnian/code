    string url = @"http://stackoverflow.com/users";
            System.Net.WebRequest request = System.Net.HttpWebRequest.Create(url);
            
            System.Net.HttpWebResponse  response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader stream = new System.IO.StreamReader
                    (response.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));
             XmlDocument rssDoc = new XmlDocument();
             rssDoc.Load(stream);
        
