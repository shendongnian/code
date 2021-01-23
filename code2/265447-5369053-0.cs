            var elements = new List<MSAFeedItem>();
            var comparison = new Comparison<MSAFeedItem>(
                (x, y) => {
                    if (x.Miles < y.Miles) return -1;
                    else if (x.Miles > y.Miles) return 1;
                    else return 0;
                });
            foreach (XElement value in _xml.Elements("channel").Elements("msa")) 
            { 
                MSAFeedItem _item = new MSAFeedItem(); 
                _item.Lat = double.Parse(value.Element("lat").Value);
                _item.Long = double.Parse(value.Element("long").Value); 
                _item.Name = value.Element("n").Value; 
                _item.Distance = Decimal.Truncate(Convert.ToDecimal(miles)); 
                elements.Add(_item); 
            }
            elements.Sort(comparison);
            msa.ItemsSource = elements;
