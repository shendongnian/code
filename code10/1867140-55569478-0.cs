    public static Project GetProject(Guid ProjectID)
    {
        if (!ProjectID.Equals(null))
        {
            using (var db = new dbEntity())
            {
                return db.Projects.Single(Project => Project.Id.Equals(ProjectID).Include(r => r.Reference);
            }
        }
        return null;
    }
