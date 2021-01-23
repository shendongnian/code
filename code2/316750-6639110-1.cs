     System.Net.WebClient client = new System.Net.WebClient();
    
            // Download URL
            Uri uri = new Uri("http://www.multiupload.com/39QMACX7XS");
    
            byte[] dbytes = client.DownloadData(uri);
            string responseStr = System.Text.Encoding.ASCII.GetString(dbytes);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(responseStr);
            string urlToDownload = doc.DocumentNode.SelectNodes("//a[contains(@href,'files/')]")[0].Attributes["href"].Value;
            byte[] data = client.DownloadData(uri);
            length = data.Length; 
