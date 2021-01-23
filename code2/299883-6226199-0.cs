    private bool Authorize(out string authCode)
    {
        bool result = false;
        authCode = "";
        string queryString = String.Format("https://www.google.com/accounts/ClientLogin?accountType=HOSTED_OR_GOOGLE&Email={0}&Passwd={1}&service=cloudprint&source={2}", UserName, Password, Source);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string responseContent = new StreamReader(response.GetResponseStream()).ReadToEnd();
        string[] split = responseContent.Split('\n');
        foreach (string s in split)
        {
            string[] nvsplit = s.Split('=');
            if (nvsplit.Length == 2)
            {
                if (nvsplit[0] == "Auth")
                {
                    authCode = nvsplit[1];
                    result = true;
                }
            }
        }
        return result;
    }
`
