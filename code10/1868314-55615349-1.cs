    var devices = dbContext.Locations
                           .Include(l => l.Devices)                           
                           .OrderBy(x => x.Name)          
                           .Select(l => new DeviceViewModel()
                           {
                              Id = l.Id,
                              Name = l.Name,
                              DevicesCount = l.Devices.Count()
                           })
                           .ToList();
