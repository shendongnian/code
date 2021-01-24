     public static int GetPosition(Uri url, string searchTerm)
            {
    
                string text = string.Format("http://www.google.com/search?num=1000&q={0}&btnG=Search", HttpUtility.UrlEncode(searchTerm));
                Console.WriteLine(text);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(text);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                    {
                        string html = reader.ReadToEnd();
                        return FindPosition(html, url);
                    }
                }
            }
            private static int FindPosition(string html, Uri url)
            {
                var reg = new Regex("<a href=\"/url\\?q=\\w+[a-zA-Z0-9.\\-?=/:]*");
                var position = 0;
                var index = 1;
                foreach (var match in reg.Matches(html))
                {
                    if (match.ToString().Contains(url.ToString()))
                    {
                        position = index;
                        break;
                    }
                    index++;
                }
                return position;
            }
