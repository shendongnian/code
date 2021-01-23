        StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), 
                                                       System.Text.Encoding.UTF8);
            queryContent = responseStream.ReadToEnd();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(queryContent);
            HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//body | //BODY");
            /* do processing here */
