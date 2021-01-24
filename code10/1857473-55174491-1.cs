    public void AddProjectManager(int projectID, AppUser user)
    {
            Project proj = context.Projects.Include(p => p.ProjectManagers)
                                  .FirstOrDefault(p => p.ProjectID == projectID);
            if(!proj.ProjectManagers.Any(pm => pm.Id = user.Id)) // <-- Here check that `AppUser` already not in Project's `ProjectManagers` collection
            {
                AppUser appUser =  context.AppUsers.FirstOrDefault(p => p.Id== user.Id);
                if(appUser != null) // <-- Confirm that the `AppUser` you are trying to add to Project's `ProjectManagers` collection is already exist in database
                {
                    proj.ProjectManagers.Add(appUser);
                    context.SaveChanges();
                }
            }
     }
