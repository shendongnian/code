    Project project = await Task.FromResult(db.Projects
        .Include(p => p.ProjectOwner)
        .Include(p => p.ChildProjects)
            .ThenInclude(o => o.ProjectOwner)
        .AsEnumerable().Where(p => p.Id == id)
        .ToList().FirstOrDefault());
