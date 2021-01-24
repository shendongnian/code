    private async Task<IList<Project>> LoadAsync(Expression<Func<Project, bool>> filter = null)
    {
        using var ctx = this.DbContextFactory.CreateDbContext();
        IQueryable<DtoProject> query = ctx.Set<DtoProject>().Include(item => item.Jobs);
        if (!(filter is null))
        {
            query = query.Where(this.Mapper.MapExpression<Expression<Func<DtoProject, bool>>>(filter));
        }
        var resultDtos = await query.ToListAsync();
        var result = resultDtos.Select(this.Mapper.Map<Project>).ToList();
        return result;
    }
    private async Task SaveAsync(Project project)
    {
        using var ctx = this.DbContextFactory.CreateDbContext();
        await ctx.Set<DtoProject>().FindAsync(p.Id == project.Id);
        await ctx.Set<DtoProject>().Persist(this.Mapper).InsertOrUpdateAsync(projectToStore);
        await ctx.SaveChangesAsync();
    }
