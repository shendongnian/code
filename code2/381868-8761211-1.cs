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
            string[] w = _url.Split('&');
            var urlParams = new List<string>();
            int urlFmtPos = 0, paramsEndPos = 0;
            string link = "";
            bool foundUrlMap = false, foundFormat = string.IsNullOrEmpty(videoFormat);
            bool gotEndPos = false;
            for (int i = 0; i < w.Length; i++) 
            {
                if (w[i].Contains("url=") && !foundUrlMap)
                {
                    foundUrlMap = true;
                    urlFmtPos = i+1;
                    
                    link = w[i].Split(new[] {"url="}, StringSplitOptions.None)[1];
                    continue;
                }
                if (w[i].Contains("url=") && foundUrlMap && foundFormat && !gotEndPos)
                {
                    gotEndPos = true;
                    paramsEndPos = i - 1;
                }
                if (!foundFormat && w[i].Contains("type="))
                {
                    if (w[i].Contains(videoFormat))
                        foundFormat = true;
                    else
                        foundUrlMap = false;
                }
            }
            for (int i = urlFmtPos; i < paramsEndPos; i++)
            {
                urlParams.Add(w[i]);
            }
            foreach (var urlparam in urlParams)
            {
                //add the parameters to the url
                link += "&" + urlparam;
            }
            link += "&title=out";
            System.Windows.MessageBox.Show(link);
            Process.Start(link);
            return link;
        }
