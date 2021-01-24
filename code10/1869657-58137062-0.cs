    static IEnumerable<string> FindSimilarItems(string html, string[] values, int maxDepth)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);
        var output = new List<string>();
        foreach (var value in values)
        {
            var rootElement = doc.DocumentNode.SelectSingleNode($"//*[text()='{value}']");
            if (rootElement == null) continue;
            for (int i = 0; i < maxDepth; i++)
            {
                var newXpath = RemoveXpathGroupIndex(rootElement.XPath, i);
                var newElements = doc.DocumentNode.SelectNodes(newXpath);
                if (newElements.Count <= 1) continue;
                output.AddRange(newElements.Select(x => x.InnerText));
            }
        }
        return output.GroupBy(x => x).Select(x => x.First()).ToList();
    }
    static string RemoveXpathGroupIndex(string xpath, int groupElement)
    {
        var splited = xpath.Split('/');
        var pickedElement = splited.Length - 1 - groupElement;
        splited[pickedElement] = splited[pickedElement].Substring(0, splited[pickedElement].IndexOf('['));
        return string.Join("/", splited);
    }
