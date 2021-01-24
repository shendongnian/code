    public async Task SaveWindowAsync(Guid facadeId, WindowEntity windowEntity)
    {
        using (ProjectsDbContext context = new ProjectsDbContext())
        {
            var facade = Facades.Single(x => x.Id == facadeId);
            windowEntity.Facade = facade;
            facade.Windows.Add(windowEntity);
            await context.SaveChangesAsync();
        }
    }
