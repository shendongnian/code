    var StaffByArea
        = areas.ToDictionary(
            a => a.Name,
            a => staff
                    .Where(c => c.AreaId == area.Id)
                    .Select(c => new SelectListItem 
                    { 
                        Value = c.AreaId.ToString(), 
                        Text = c.Username 
                    }));
