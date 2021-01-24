    var list1 = list.GroupBy(y => y.columnName1)
                    .Select(group => new CountryViewModel
                    {
                        Name = group.Key,
                        Result = group.Sum(x => x.columnName2)
                    })
                    .ToList();
    
    
     return View(list1);
