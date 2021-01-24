      Item = (from it in _context.Item.Include("ItemVersions.OriginalTitles")
                    join iv in _context.ItemVersions on it.Id equals iv.ItemId
                    join iot in _context.ItemOriginalTitles on iv.Id equals iot.ItemVersionId
                    where term.ToLower() == "all" || (it.Name.ToLower() == term.ToLower() || it.Name.ToLower().Contains(term.ToLower()) || iot.Value.Contains(term) ||
                    queryable.Any(x => iot.Value.Contains(x.SearchText)))
                    select it          
           ).Distinct().ToList().ToList();
