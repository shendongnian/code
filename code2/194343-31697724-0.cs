    string A = HttpContext.Current.Server.HtmlDecode(Text);
    string A = Text.Replace("&nbsp"," ");
    string A = Text.Replace("&amp;nbsp;", " ");
                  
                               ↑ &amp;nbsp;
