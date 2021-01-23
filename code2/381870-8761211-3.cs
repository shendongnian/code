        public string url(string url, string videoFormat)
        {
            HtmlAgilityPack.HtmlDocument hDoc = new HtmlDocument();
            hDoc.Load(new WebClient().OpenRead(url));
            HtmlNode node = hDoc.GetElementbyId("movie_player");
            string flashvars = node.Attributes[5].Value;
            string _url = string.Empty;
            //Crazy string!
            _url = Uri.UnescapeDataString(flashvars);
            _url = HttpUtility.HtmlDecode(_url);
            _url = HttpUtility.UrlDecode(_url);
            _url = Uri.UnescapeDataString(_url);
            string[] w = _url.Split(new[] {"url="}, StringSplitOptions.None);
            string link = "";
            if(!string.IsNullOrEmpty(videoFormat))
            {
                foreach (string t in w)
                {
                    if(t.Contains("type=") && t.Contains(videoFormat))
                    {
                        link = t;
                        break;
                    }
                }
            }
            else
            {
                link = w[0];
            }
            
            link += "&title=out";
            System.Windows.MessageBox.Show(link);
            Process.Start(link);
            return link;
        }
