            WebClient client = new WebClient();
            string url = "Your URL";
            Byte[] requestedHTML;
            requestedHTML = client.DownloadData(url);
            string htmlcode = client.DownloadString(url);
            //client.DownloadFile(url, @"E:\test.html");
            UTF8Encoding objUTF8 = new UTF8Encoding();
            string html = objUTF8.GetString(requestedHTML);           
            MatchCollection m1 = Regex.Matches(html, @"(<h3>(.*?)</h3>)",
            RegexOptions.Singleline);
            foreach (Match m in m1)
            {
                string cell = m.Groups[1].Value;
                Match match = Regex.Match(cell, @"<h3>(.+?)</h3>");
                if (match.Success)
                {
                    string value = match.Groups[1].Value;
                }
            }
