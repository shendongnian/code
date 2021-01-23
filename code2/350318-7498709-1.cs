    public static string GetPathRelativeToExecutingAssemblyLocation(string aRelativePath)
    {
        return Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
            aRelativePath);
    }
