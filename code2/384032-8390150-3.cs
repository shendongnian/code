    public static void GoogleSearch2(string keyword)
    {
        string url = "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=8&q="+keyword;
        using(WebClient wc = new WebClient())
        {
            wc.Encoding = System.Text.Encoding.UTF8;
            wc.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E)";
            string jsonStr = wc.DownloadString(url);
            JObject jObject = (JObject)JsonConvert.DeserializeObject(jsonStr);
            foreach (JObject result in jObject["responseData"]["results"])
            {
                Console.WriteLine(
                    result["titleNoFormatting"] + "\n" +
                    result["content"] + "\n" +
                    result["unescapedUrl"] + "\n");
            }
        }
    }
