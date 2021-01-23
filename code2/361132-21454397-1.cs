    public Project GetProject(int id)
        {
            using (var context = new Context())
            {
                var project = context.Projects
                    .Include(p => p.Reports.Select(q => q.Issues.Select(r => r.Profession)))
                    .Include(p => p.Reports.Select(q => q.Issues.Select(r => r.Room)))
                    .SingleOrDefault(x => x.Id == id);
                return project;      
            }
        }
