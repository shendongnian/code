     XElement _xml = XElement.Load("MSA.xml");
            {
                msa.Items.Clear();
                List<MSAFeedItem> tempItems = new List<MSAFeedItem>();
    
                foreach (XElement value in _xml.Elements("channel").Elements("msa"))
                {
                    MSAFeedItem _item = new MSAFeedItem();
                    _item.Lat = double.Parse(value.Element("lat").Value);
                    _item.Long = double.Parse(value.Element("long").Value);
                    _item.Name = value.Element("n").Value;
    
    
                    double dis1 = _item.Lat - curLatitude;
                    double dis2 = _item.Long - curLongitude;
    
                         var miles1 = Math.Pow(dis1, 2.0);
                         var miles2 = Math.Pow(dis2, 2.0);
    
                         var miles3 = miles1 + miles2;
    
                         var miles4 = Math.Sqrt(miles3) ;
    
                         var miles = miles4 * 62.1371192;
    
                        _item.Distance = Decimal.Truncate(Convert.ToDecimal(miles));
    
                     tempItems.Add(_item);
    
                }
              
                msa.Items.AddRange(tempItems.OrderBy( i => i.Distance) );
               
            }
