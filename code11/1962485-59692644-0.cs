context.ProjectRoles
       .GroupBy(p => new { p.Role, p.UserId })
       .Where(g => g.Key.Role == "Admin" &&
                   g.Count() == 1 &&
                   g.All(z => z.UserId == userId)
             );
