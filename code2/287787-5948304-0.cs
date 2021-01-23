    string fromCulture = from.Name;
                string toCulture = to.Name;
                string translationMode = string.Concat(fromCulture, "_", toCulture);
    
                string url = String.Format("http://babelfish.yahoo.com/translate_txt?lp={0}&tt=urltext&intl=1&doit=done&urltext={1}", translationMode, HttpUtility.UrlEncode(resource));
                WebClient webClient = new WebClient();
                webClient.Encoding = System.Text.Encoding.Default;
                string page = webClient.DownloadString(url);
    
                int start = page.IndexOf("<div style=\"padding:0.6em;\">") + "<div style=\"padding:0.6em;\">".Length;
                int finish = page.IndexOf("</div>", start);
                string retVal = page.Substring(start, finish - start);
