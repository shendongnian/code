    var filteredItems = e.Result.Selecting(entity => 
                        new FilteredItem
                        {
                          Property1 = entity.Property1,
                          Property2 = entity.Property2,
                          Property3 = entity.Property3
                        }).Distinct();
