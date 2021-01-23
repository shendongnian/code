    private void ProcessResponse()
    {    
                var items = 10;
                XDocument results = XDocument.Parse(_responseString);
    
                _StaffNews = (from item in results.Descendants(XName.Get("row", "#RowsetSchema"))
                        //where !item.Element("NewsThumbnail").Attribute("src").Value.EndsWith(".gif")
                        select new StaffNews()
                        {                   
                            Title = item.Attribute("ows_Title").Value,
                            NewsBody = item.Attribute("ows_NewsBody").Value,
                            NewsThumbnail = FormatImageUrl(item.Attribute("ows_NewsThumbnail").Value),
                            DatePublished = item.Attribute("ows_Date_Published").Value,
                            PublishedBy = item.Attribute("ows_PublishedBy").Value,
                        }).Take(items);
                this.DataContext = _StaffNews;
                //NewsList.SelectedIndex = -1;            
    }
