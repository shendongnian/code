    HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement el in elc)
                {
                    if (el.GetAttribute("type").Equals("text") && el.GetAttribute("name").Equals("ip"))
                    {
                        el.InnerText = "Server IP";
                    }
                }
