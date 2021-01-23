            HtmlDocument doc = new HtmlDocument();
            doc.Load("yourDoc.Htm");
            // Get A nodes that have an HREF attribute
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//b/a[@href]"))
            {
                // This will contain anchor's displayed text
                string title = node.InnerText;
                Console.WriteLine("title=" + title);
                // Get the 1st BR, and then it's next sibling of TEXT type.
                HtmlNode sizeNode = node.SelectSingleNode("../following-sibling::br[1]/following-sibling::text()");
                Console.WriteLine(" size=" + sizeNode.InnerText.Trim());
                // Get the 3nd BR, and then it's next sibling of TEXT type.
                HtmlNode eanNode = node.SelectSingleNode("../following-sibling::br[2]/following-sibling::text()");
                Console.WriteLine(" ean=" + eanNode.InnerText.Trim());
                // Get the 3rd BR, and then it's next sibling of TEXT type.
                HtmlNode upcNode = node.SelectSingleNode("../following-sibling::br[3]/following-sibling::text()");
                Console.WriteLine(" upc=" + upcNode.InnerText.Trim());
            }
