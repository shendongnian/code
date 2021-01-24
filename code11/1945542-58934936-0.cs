        public async Task SaveWindowAsync(Guid projectId, Guid houseId, Guid facadeId, WindowEntity windowEntity)
    {
        using (ProjectsDbContext context = new ProjectsDbContext())
        {
            var windowList = context.ProjectSet
                .SelectMany(p => p.Houses
                .SelectMany(h => h.Facades
                .SelectMany(f => f.Windows)));
            windowList.Add(windowEntity);
            await context.SaveChangesAsync();
        }
    }
