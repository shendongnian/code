    var groups = from item in LineItems
                 let startDate = item.TransDate
                 group item by LineItems.Select(lineItem => lineItem.TransDate)
                                        .SkipWhile(endDate => endDate < startDate)                                        
                                        .TakeWhile((endDate, index) => 
                                                    startDate.AddDays(index) == endDate)
                                        .Last();
    //If required:
     var groupsAsLists = groups.Select(g => g.ToList()).ToList();
