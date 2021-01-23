        private string GetDDLValueByName(HtmlDocument doc, string Name)
        {
            string Value = "";
            HtmlElementCollection selects = GetElementCollectionFromDocument(webBrowser1.Document, "SELECT");
            if (selects != null)
            {
                foreach (HtmlElement select in selects)
                {
                    if (select.Name == Name)
                    {
                        HtmlElementCollection children = select.Children;
                        if (children.Count > 0)
                        {
                            foreach (HtmlElement child in children)
                            {
                                if (child.OuterHtml.Contains("selected"))
                                    return child.InnerText;
                            }
                        }
                        else
                            return "";
                    }
                }
            }
            return Value;
        }
