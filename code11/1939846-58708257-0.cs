    List<Item> Item = from it in _context.Item
                      join iv in _context.ItemVersions.Include("OriginalTitles") on it.Id equals iv.ItemId
                      join iot in _context.ItemOriginalTitles on iv.Id equals iot.ItemVersionId                    
                      where term.ToLower() == "all" || (it.Name.ToLower() == term.ToLower() || it.Name.ToLower().Contains(term.ToLower()) || iot.Value.Contains(term) || 
                      queryable.Any(x => iot.Value.Contains(x.SearchText)))
                      select new Item
                      {
                          Id = it.Id,
                          Name = it.Name,
                          TypeCodeId = it.TypeCodeId,
                          TypeCode = it.TypeCode,
                          OriginalLangId = it.OriginalLangId,
                          SubGenreCodeId = it.SubGenreCodeId,
                          ItemVersions = it.ItemVersions
                      };
