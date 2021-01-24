    public void AddProjectManager(int projectID, AppUser user)
    {
            Project proj = context.Projects.Include(p => p.ProjectManagers)
                                  .FirstOrDefault(p => p.ProjectID == projectID);
            if(!proj.ProjectManagers.Any(pm => pm.Id = user.Id))
            {
                AppUser appUser =  context.AppUsers..FirstOrDefault(p => p.Id== user.Id);
                if(appUser != null)
                {
                    proj.ProjectManagers.Add(appUser);
                    context.SaveChanges();
                }
            }
     }
