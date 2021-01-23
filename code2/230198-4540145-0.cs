        System.Web.Script.Serialization.JavaScriptSerializer sr = new System.Web.Script.Serialization.JavaScriptSerializer();
        System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(@"https://graph.facebook.com/100000570310973_181080451920964");
        req.Method = "GET";
        System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse();
        byte[] resp = new byte[(int)res.ContentLength];
        int bytestoread = 0;
        for (int i = 0; i < (int)res.ContentLength;)
        {
            bytestoread = (i + 64 < (int)res.ContentLength) ? 64 : 64 - ((i + 64) - (int)res.ContentLength);
            i += res.GetResponseStream().Read(resp, i, bytestoread);
        }
        string data = Encoding.UTF8.GetString(resp);
        FacebookFeed feed = sr.Deserialize<FacebookFeed>(data);
