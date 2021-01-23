     HtmlElementCollection oHtmlElementCollection;
            public List<string> lstDetailsUrl = new List<string>();
                                oHtmlElementCollection = webBrowser1.Document.GetElementsByTagName("div");
                                lstDetailsUrl.Clear();
                                for (int i = 0; i < oHtmlElementCollection.Count; i++)
                                {
                                    if (oHtmlElementCollection[i].GetAttribute("id") != null)
                                    {
                                        if (oHtmlElementCollection[i].GetAttribute("id").Contains("title"))
                                        {
                                            lstDetailsUrl.Add(oHtmlElementCollection[i].InnerText);
                                        }
                                    }
                                }
