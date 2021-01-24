    public IEnumerable<SelectListItem> ShiftManagersList
    {
        get {  var managers = dbContext.ShiftManagers.Select(f => new SelectListItem
                                               {
                                                   Value = f.Id.ToString(),
                                                   Text = $"{f.Name} {f.Surname}"           
                                              });
              return managers;
            }
    }
