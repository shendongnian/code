            result = userRoles.GroupBy(l => l.User).Select(u => new UserRole()
            { 
                Code = string.Join(", ", u.Select(d => d.Code).ToArray()),
                User = u.Key,
                Role = u.First().Role
            }).ToList();
