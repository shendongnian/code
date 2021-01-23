        static void ReplaceNodesWithContent(XElement element, string targetElementname)
        {
            if (element.Name == targetElementname)
            {
                element.ReplaceWith(element.Value);
                return;
            }
            foreach (var child in element.Elements())
            {
                ReplaceNodesWithContent(child, targetElementname);
            }
        }
