        HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("INPUT");
        foreach (HtmlElement elem in elems)
        {
            String valueStr = elem.GetAttribute("value");
            if (nameStr != null && valueStr.Equals("Login"))
            {
                elem.InvokeMember("click");                
            }
        }
