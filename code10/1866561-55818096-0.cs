    public void Delete(string Input)
    {
        try
        {
            var children = GetChildren(Input);
    
            foreach(var child in children)
            {
                Delete(child.Id);
            }
    
            var repo = Get(Input);
            dbContext.Repositories.Remove(repo);
            dbContext.SaveChanges();
            logger.LogInformation(LoggingGlobals.Delete + " Repository: " + repo.Name);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to delete Repository");
        }
    }
