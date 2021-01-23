            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("http://www.bodybuilding.com/exercises/detail/view/name/alternating-floor-press");
            IEnumerable<HtmlNode> threadLinks = doc.DocumentNode.SelectNodes("//*[@id=\"exerciseDetails\"]");
            foreach (var link in threadLinks)
            {
                string str = link.InnerText;
                Console.WriteLine(str);
            }
            Console.ReadKey();
