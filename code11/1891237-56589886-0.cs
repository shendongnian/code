    var staffViewModels = context.Staff
        .Select(x => new StaffViewModel
        {
            StaffId = x.Id,
            Name = x.Name,
            Country = x.City.Country.Name
        }).ToList();
