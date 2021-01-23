    public static class DirectoryNotFoundExceptionExtentions
    {
        public static string GetPath(this DirectoryNotFoundException dnfe)
        {
            System.Text.RegularExpressions.Regex pathMatcher = new System.Text.RegularExpressions.Regex(@"[^']+");
            return pathMatcher.Matches(dnfe.Message)[1].Value;
        }
    }
