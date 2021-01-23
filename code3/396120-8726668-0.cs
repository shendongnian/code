    public List<Student> GetStudentsByProject(int pgid)
    {
        return this.ObjectContext.ProjectGroup.Where(pg => pg.pgid == pgid)
                   .Select(pg => pg.Students).ToList();
    }
