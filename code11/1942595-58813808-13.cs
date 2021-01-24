    public IActionResult ViewByDate(string startDate, string endDate, int? page)
    {
        string[] dates = { startDate, endDate };
        List<UserMovements> filtered;
        var currentPageNum = page.HasValue ? page.Value : 1;
        var offset = (DefaultPageSize * currentPageNum) - DefaultPageSize;
        var model = new ViewByDateViewModel();
        model.StartDateFilter = startDate==null? DateTime.Now:DateTime.Parse(startDate);
        model.EndDateFilter = endDate == null ? DateTime.Now : DateTime.Parse(endDate);
        int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
        if (startDate == null && endDate == null)
        {
            filtered = this.allMovements.ToList();
        }
        else
        {
            filtered = this.allMovements
                .Where(p => p.Date.Date >= DateTime.Parse(startDate) && p.Date.Date <= DateTime.Parse(endDate))
                .ToList();
        }
        model.UserMovements.Data = filtered
            .Skip(offset)
            .Take(DefaultPageSize)
            .ToList();
        model.UserMovements.PageNumber = currentPageNum;
        model.UserMovements.PageSize = DefaultPageSize;
        model.UserMovements.TotalItems = filtered.Count;
        return View(model);
    }
    
