    public async Task SaveWindowAsync(Guid projectId, Guid houseId, Guid facadeId, WindowEntity windowEntity)
    {
        using (ProjectsDbContext context = new ProjectsDbContext())
        {            
            windowEntity.FacadeId = facadeId;
            context.WindowSet.Add(windowEntity);
            await context.SaveChangesAsync();
        }
    }
