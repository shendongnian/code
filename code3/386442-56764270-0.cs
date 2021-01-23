    public void HideDivByClassName(WebBrowser browser, string classname)
            {
                if (browser.Document != null)
                {
                    var byTagName = browser.Document.GetElementsByTagName("div");
                    foreach (HtmlElement element in byTagName)
                    {
                        if (element.GetAttribute("className") == classname)
                        {
                            element.Style = "display:none";
                        }
                    }
                }
            }
