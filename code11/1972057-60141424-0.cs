      public bool Unstage(params string[] filePaths)
    {
        using (var repo = LocalRepo)
        {
            try
            {
                foreach (var filePath in filePaths)
                {
                   Commands.Unstage(repo, filePath);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        return true;
    }
