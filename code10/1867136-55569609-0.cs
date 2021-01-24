    public string GetExternalUrl(string linkUrl)
            {
                var result = string.Empty;
                try
                {
                    var url = new UrlBuilder(linkUrl);
                    Global.UrlRewriteProvider.ConvertToExternal(url, linkUrl, Encoding.UTF8);
                    result = url.ToString();
                }
                catch (Exception)
                {
                }
                return result;
            }
