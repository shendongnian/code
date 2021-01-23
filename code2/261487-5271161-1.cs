        List<string> listOfUrls = new List<string>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(@"c:\ht.html");
            HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("//li[@class='interwiki-sv']");
            foreach (HtmlNode li in coll)
            {
                if (li.ChildNodes.Count < 1) continue;
                HtmlNode node = li.ChildNodes.First();
                if (null == node) continue;
                HtmlAttribute att = node.Attributes["href"];
                if (null == att) continue;
                listOfUrls.Add(att.Value);
            }
        //Now, You got your listOfUrls to process.
