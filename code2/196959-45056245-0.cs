    public static DateTime GetPasswordExpirationDate(string userId)
        {
            string forestGc = String.Format("GC://{0}", Forest.GetCurrentForest().Name);
            var searcher = new DirectorySearcher();
            searcher = new DirectorySearcher(new DirectoryEntry(forestGc));
            searcher.Filter = "(sAMAccountName=" + userId + ")";
            var results = searcher.FindOne().GetDirectoryEntry();
            return (DateTime)results.InvokeGet("PasswordExpirationDate");
        }
