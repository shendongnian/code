        String username = "Superman"; // Obviously handled secretly
        String pw = "ILoveLex4evar!"; // Obviously handled secretly
        String url = "https://www.SuperSecretServer.com/123&stuff=?uhh";
        String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + pw));
        CookieContainer myContainer = new CookieContainer();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add("Authorization", "Basic " + encoded);
        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream xml = File.Create("filepath/filename.xml"))
                    {
                        byte[] buffer = new byte[BufferSize];
                        int read;
                        while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            xml.Write(buffer, 0, read);
                        }
                    }
                }
            }
        }
