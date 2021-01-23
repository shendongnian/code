    public static class ErrorMessages
    {
        public static string SurnameRequired
        {
            get { return LoadLocalizedMessage("SurnameRequired"); }
        }
        private static string LoadLocalizedMessage(string key)
        {
            var culture = CultureInfo.CurrentCulture;
            // Query the database or some local cache.
        }
    }
