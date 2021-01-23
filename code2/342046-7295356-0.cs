    class Program
    {
        static void Main()
        {
            var doc = new HtmlDocument();
            doc.Load("test.html");
            var anchor = doc.DocumentNode.SelectSingleNode("//a[contains(@href, 'url-a')]");
            if (anchor != null)
            {
                var id = anchor.ParentNode.SelectSingleNode("following-sibling::td/a");
                if (id != null)
                {
                    Console.WriteLine(id.InnerHtml);
                    var img = id.ParentNode.SelectSingleNode("following-sibling::td/a");
                    if (img != null)
                    {
                        Console.WriteLine(img.InnerHtml);
                    }
                }
            }
        }
    }
