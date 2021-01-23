    public Project DeleteProject(int id)
        {
            using (var context = new Context())
            {
                var p = context.Projects.SingleOrDefault(x => x.Id == id);
                if (p == null)
                    return p;
                context.Projects.Remove(p);
                context.SaveChanges();
                return p;
            }
        }
