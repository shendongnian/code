           // Query for all departments without tracking them
           var departments1 = context.Departments.AsNoTracking().ToList();
          // Query for some departments without tracking them
          var departments2 = context.Departments
                    .Where(d => d.Name.StartsWith("math"))
                    .AsNoTracking()
                    .ToList();
