    var result = this.context.Teams.Where(t=>t.EndDateTime==null).Select(t=>
    new { Name = t.Name,
                 PropertyX = t.PropertyX... //pull any other needed team properties.
                 CareCoordinators = t.CareCoordinators.Where(c=>c.EndDateTime==null)
    }).ToList();
