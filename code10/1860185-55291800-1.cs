    var result = Projects
        .Where(p => p.ProjectManagers.Any(pm => pm.Id == user.Id)
               || p.Users.Any(u => u.Id == user.Id))
        .Select(x => new { UserId = user.Id, Projects = x })
        .GroupBy(p => p.UserId)
        .Select(x => x.OrderByDescending(p => p.Projects.ProjectID).First());
