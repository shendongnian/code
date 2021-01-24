    HtmlElement Buildingcontacts = webBrowser1.Document.GetElementById("ID2");
    HtmlElementCollection ifiels = Buildingcontacts.Document.GetElementsByTagName("td");
                foreach (HtmlElement element in ifiels)
                {
                    string datafieldx = element.GetAttribute("data-field");
                    if (datafieldx == "2")
                    {
                        if (element.InnerText != null)
                        {
                           //do Somthing
                        }
                    }
                }
