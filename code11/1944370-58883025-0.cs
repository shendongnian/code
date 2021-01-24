    def.Paging = true;
                def.ItemsPerPage = 25;
                def.MaxItemsPerPage = 25;
    
                def.RetrieveData = (context) =>
                {
    
                    var options = context.QueryOptions;
    
                    var result = new QueryResult<DepositLog>();
    
                    var query = _modelItems.AsQueryable();
    
                    result.TotalRecords = query.Count();
    
                    if (options.GetLimitOffset().HasValue)
                    {
                        query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
                    }
                    result.Items = query.ToList();
    
                    return result;
                };
