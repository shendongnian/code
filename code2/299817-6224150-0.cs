            WebClient client = new WebClient();
            string url = "Your URL";
            Byte[] requestedHTML;
            requestedHTML = client.DownloadData(url);
            string htmlcode = client.DownloadString(url);
            //client.DownloadFile(url, @"E:\test.html");
            UTF8Encoding objUTF8 = new UTF8Encoding();
            string html = objUTF8.GetString(requestedHTML);           
            StringReader reader = new StringReader(html);
            String line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
