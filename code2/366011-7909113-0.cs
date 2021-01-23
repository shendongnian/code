    public static void decryptContainer(string dlc_content) 
    {
        using (var client = new WebClient())
        {
            var values = new NameValueCollection
            {
                { "content", dlc_content }
            };
            client.Headers[HttpRequestHeader.Accept] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            string url = "http://dcrypt.it/decrypt/paste";
            byte[] result = client.UploadValues(url, values);
            Console.WriteLine(Encoding.UTF8.GetString(result));
        }
    }
