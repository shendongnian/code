    // First, make a list containing just one item, with Id id:
    var rootProjects = db.Projects
        .Include(p => p.ProjectOwner)
        .Include(p => p.ChildProjects)
        .AsEnumerable()
        .Where(p => p.Id == id).ToList();
    // Put the result in a single project variable:
    var project = rootProjects.FirstOrDefault();
