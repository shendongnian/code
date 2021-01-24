    var rootProjects = db.Projects
        .Include(p => p.ProjectOwner)
        .Include(p => p.ChildProjects)
        .AsEnumerable()
        .Where(p => p.ParentId == null).ToList();
