    public void RemoveEmployeeFromProject(int projectId)
    {
        var project = Context.Projects.FirstOrDefault(x => x.ProjectId == projectId);
        project.EmployeeId = (int?)null;
        Context.SaveChanges();
    }
