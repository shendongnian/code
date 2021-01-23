    XElement xdoc = XElement.Parse(e.Result);
    XNamespace test = "http://foo.bar";
    this.newsList.ItemsSource = from item in xdoc.Descendants("item")
                                select new ArticlesItem
                                {
                                    LinkID = item.Element(test + "link_id").Value,
                                    Title = item.Element("title").Value,
                                    Description = this.Strip(item.Element("description").Value).Substring(0, 200).ToString()
                                }
