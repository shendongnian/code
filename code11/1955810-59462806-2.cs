    string htmlFile = File.ReadAllText(@"TempFile.html");
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(htmlFile);
    HtmlNode htmlDoc = doc.DocumentNode;
    HtmlNode node = htmlDoc.SelectSingleNode("//span[@class='ds-hero-headline ds-schools-display-rating']");
    Console.WriteLine(node.InnerText);
    // output: 8
When you search with //span, it will search the entire document. You can search specific divs if you know which one it would be under. You can use the dot notation to search under a specific tree.
    HtmlNode node2 = htmlDoc.SelectSingleNode("//div[@class='ds-gs-rating-8']");
    HtmlNode subNode = node2.SelectSingleNode(".//span[@class='ds-hero-headline ds-schools-display-rating']");
    Console.WriteLine(subNode.InnerText);
    
    // output: 8
You can also print the XPath to see where it is
    Console.WriteLine(subNode.XPath);
    //output: /div[1]/div[1]/div[1]/div[1]/span[1]
Also, wrote a method that you can use to look up a specific node with a class name.
    public static HtmlNode FindNodeWithClass(HtmlNode htmlDoc, string classToFind)
    {
        if (htmlDoc.HasChildNodes)
            foreach(HtmlNode node in htmlDoc.ChildNodes)
            {
                if (node.HasChildNodes)
                {
                    HtmlNode nodeToBe = FindNodeWithClass(node, classToFind);
                    if (nodeToBe != null)
                        return nodeToBe;
                }
                    
                foreach (string className in node.ParentNode.GetClasses())
                    if (className.Equals(classToFind))
                        return node.ParentNode;
            }
        return null;
    }
    //Usage:
    HtmlNode result = FindNodeWithClass(htmlDoc, "ds-hero-headline");
