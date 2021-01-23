    public Project DeleteProject(int id)
        {
            using (var context = new Context())
            {
                var p = GetProject(id);
                context.Projects.Remove(p);
                context.SaveChanges();
                return p;
            }
        }
