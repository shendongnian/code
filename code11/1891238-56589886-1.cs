    var staffViewModels = context.Staff
        .Select(x => new StaffViewModel
        {
            StaffId = x.Id,
            Name = x.Name,
            Country = x.Address.City.Country.Name
        }).ToList();
