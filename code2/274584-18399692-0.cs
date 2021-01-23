    HtmlElementCollection htmlcol = ((WebBrowser)sender).Document.GetElementsByTagName("input");
    for (int i = 0; i < htmlcol.Count; i++)
                {
                    if (htmlcol[i].GetAttribute("value") == "Search")
                    {
                        htmlcol[i].InvokeMember("click");
                    }
                }
