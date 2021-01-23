        return new DataAccess() 
            .Categories 
            .OrderBy(c => c.Description)
            .AsEnumerable()
            .Select(c => new SelectListItem 
                { 
                    Value = c.Id.ToString(), 
                    Text = c.Description 
                }); 
