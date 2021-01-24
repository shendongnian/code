    public static async Task SaveWindowAsync(Guid projectId, Guid houseId, Guid facadeId, Window windowEntity)
    {
        using (ProjectsDbContext context = new ProjectsDbContext())
        {
            var facade = context.Set<Facade>()
                                .Where(f => f.FacadeId == facadeId)
                                .Single();
                             
            facade.Windows.Add(windowEntity);
            await context.SaveChangesAsync();
        }
    }
