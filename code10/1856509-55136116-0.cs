     List lmsList = clientContext.Web.Lists.GetByTitle("LargeList");
                    ListItemCollectionPosition itemPosition = null;
                    while (true)
                    {
                        CamlQuery camlQuery = new CamlQuery();
                        camlQuery.ListItemCollectionPosition = itemPosition;
                        camlQuery.ViewXml = @"<View><RowLimit>500</RowLimit></View>";
    
                        ListItemCollection listItems = lmsList.GetItems(camlQuery);
                        clientContext.Load(listItems);
                        clientContext.ExecuteQuery();
    
                        itemPosition = listItems.ListItemCollectionPosition;
                        Console.WriteLine(itemPosition);
                        //foreach (ListItem listItem in listItems)
                        //    Console.WriteLine("Item Title: {0}", listItem["Title"]);
    
                        if (itemPosition == null)
                            break;
    
                        Console.WriteLine(itemPosition.PagingInfo);                    
                    }
