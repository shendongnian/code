    long selectedValue = cb_Projects.SelectedValue;
    Project p = db.Projects.Include(p => p.Customers)
                           .Include(p => p.Workers)
                           .Include(p => p.Materials)
                           .Single(p => p.ProjectID == selectedValue);
