    public static async Task SaveWindowAsync(Guid projectId, Guid houseId, Guid facadeId, Window windowEntity)
    {
        using (ProjectsDbContext context = new ProjectsDbContext())
        {
            context.Entry(windowEntity).Property("FacadeId").CurrentValue = facadeId;
            context.Set<Window>().Add(windowEntity);
            await context.SaveChangesAsync();
        }
    }
