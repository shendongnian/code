    HtmlElementCollection collection = pageContent.GetElementsByTagName("HTML");
    IHTMLDOMNode htmlNode = (IHTMLDOMNode)collection[0];
    ProcessChildNodes(htmlNode);
    
    private void ProcessChildNodes(IHTMLDOMNode node)
    {
        foreach (IHTMLDOMNode childNode in node.childNodes)
        {
            if (childNode.nodeType == 3)
            {
                // ...
            }
            ProcessChildNodes(childNode);
        }
    }
