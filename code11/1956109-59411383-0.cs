lang-c#
var projectsDetailVm = _gradeContext.Projects
    .Where(m => m.Id == ProjectId)
    .Select(project => new ProjectsDetailVm
    {
        ProjectId = project.Id,
        Name = project.Name,
        CreationDate = project.CreationDate,
        CreatedByUserId = project.CreatedByUserId,
        Description = project.Description,
        CompanyId = project.Company.Id,
        CompanyName = project.Company.Name,
        DeletionDate = project.DeletionDate,
        DeletedByUserId = project.DeletedByUserId,
        UpdateDate = project.UpdateDate,
        UpdatedByUserId = project.UpdatedByUserId,
        IsDeleted = project.IsDeleted
    }).SingleOrDefault();
As it stands currently, your `if(projectsDetailVm == null)` will never be `true` because if there are no rows then `projectsDetailVm` will be an empty collection and not `null`. I assume you only expect one `ProjectsDetailVm` because of `Where(m => m.Id == ProjectId)`.
