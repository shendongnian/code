    [HttpPost]
            public async Task<JsonResult> LoadList()
            {
               var search = Request.Form["search[value]"] + "";
    
                var totalCount = 0;
                var fList = _context.Expenses.Include(x => x.AccountType).AsQueryable();
                if (!string.IsNullOrEmpty(search))
                {
                    fList = fList.Where(x => x.Description.ToLower().Trim().Contains(search.ToLower().Trim()));
                }
                
                var list = await fList.OrderByDescending(x => x.Id).Skip(start).Take(length).Select(x => new
                {
                    x.Id,
                    x.Amount,
                    Date = x.Date != null ? x.Date.Value.ToString("dd-MMM-yyyy") : "",
                    Type = x.AccountTypeId != null ? x.AccountType.Name : "",
                    x.Description,
                    x.BillAmount,
                    x.Payment,
                    x.AccountTypeId
                }).ToListAsync();
    
                if (list.Any())
                {
                    totalCount = fList.Count();
                }
    
                var result = JObject.FromObject(new
                {
                    draw,
                    recordsFiltered = totalCount,
                    recordsTotal = totalCount,
                    data = list
                });
                return result;
            }
