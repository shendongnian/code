    public static Project GetProject(Guid ProjectID)
    {
        if (!ProjectID.Equals(null))
        {
            using (var db = new dbEntity())
            {
                return db.Projects.Include(r => r.Reference).Single(Project => Project.Id.Equals(ProjectID));
            }
        }
        return null;
    }
