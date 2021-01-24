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
        Project MapToStored(DtoProject dtoProject)
        {
            var result = this.Mapper.Map<Project>(dtoProject);
            this.Mapper.Map(project, result);
            return result;
        }
        Expression<Func<Project, bool>> filter = p => p.Id == project.Id;
        using var ctx = this.DbContextFactory.CreateDbContext();
        var storedDtoProject = await ctx.Set<DtoProject>().Include(p => p.Jobs).FirstOrDefaultAsync(this.Mapper.MapExpression<Expression<Func<DtoProject, bool>>>(filter));
        var projectToStore =
            !(storedDtoProject is null) ?
                MapToStored(storedDtoProject) :
                project;
        await ctx.Set<DtoProject>().Persist(this.Mapper).InsertOrUpdateAsync(projectToStore);
        await ctx.SaveChangesAsync();
    }
