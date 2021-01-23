    public IQueryable<Student> GetStudentsByGroup(int projectGroupId)
    {
        return this.ObjectContext.Students
                   .Where(x => x.ProjectGroup.pgid == projectGroupId);
    }
