        var r = records.GroupBy(x => new {x.Id, x.Name})
    	               .Select(x => new {
                           ID = x.Key.ID,
                		   Name = x.Key.Name,
    		               RevObj = x.OrderBy(y => y.Rev).LastOrDefault(y => y.Status != "Cancel") ??
                                    x.OrderBy(y => y.Rev).Last(y => y.Status == "Cancel")
    		           })
                       .ToArray()
                       .Select(x => new Record() {
                           ID = x.ID,
                           Name = x.Name,
                           Rev = x.RevObj.Rev
                       })
                       .ToList();
