           string FindUrl(string url)
                {
              
     Regex r1=    new Regex("((http://|www\\.)([A-Z0-9.-:]{1,})\\.[0-9A-Z?;~&#=\\-_\\./]{2,})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
                MatchCollection mc = r1.Matches(url);
                foreach (Match m in mc)
                {
                    url = url.Replace(m.Value, "<a href='" + m.Value + "'>" + m.Value + "</a>");
                }
                    return url;
        
                }
