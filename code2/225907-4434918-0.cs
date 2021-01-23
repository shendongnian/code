     XElement _xml;
            try
            {
                if (!e.Cancelled)
                {
                    _xml = XElement.Parse(e.Result);
                    Results.Items.Clear();
                    foreach (XElement value in _xml.Elements("runner").Elements("rr_event"))
                    {
                        FeedItem _item = new FeedItem();
                        _item.Title = value.Element("title").Value;
                        _item.Description = Regex.Replace(value.Element("description").Value,
                        @"<(.|\n)*?>", String.Empty);
                        _item.Sector = value.Element("sector").Value;
    
                        if("A".equals(_item.Sector)) Results.Items.Add(_item);
                    }
                }
            }
