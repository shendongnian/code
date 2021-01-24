    var filterItems = primaryHeaders.Cast<SPListItem>()
                                    .Where(p => p["Header1Ref"].ToString() == "a");
                    foreach(var item in filterItems)
                    {
                        Console.WriteLine(item.Title);
                    }
