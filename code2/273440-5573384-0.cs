    foreach (MapItem item in mapItems)
                {
    
                    var sameAddress = from m in mapItems
                                      group m by m.Address into ms
                                      select string.Join("", ms.Select(e => e.Html).ToArray());
    
                    foreach (string concatHtml in sameAddress)
                    {
                        item.Html = concatHtml;
                    }
                    
                }
