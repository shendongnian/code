    var items = from item in _repository.GetStreamItems()
                            select new
                            {
                                Title = item.Title,
                                Description = item.Description,
                                MetaData = item.MetaData,
                                ItemType = item.ItemType,
                                Items = from subItem in (item.Items ?? Enumerable.Empty<Item>())
                                        select new
                                        {
                                            Title = subItem.Title,
                                            Description = subItem.Description,
                                            MetaData = subItem.MetaData,
                                            ItemType = subItem.ItemType
                                        }
                            };
