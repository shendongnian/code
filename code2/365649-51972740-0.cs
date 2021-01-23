        public static string GetUserIdFromConnectionString(string connectionString)
        {
            return new Regex("USER\\s+ID\\=\\s*?(?<UserId>\\w+)",
                    RegexOptions.IgnoreCase)
                .Match(connectionString)
                .Groups["UserId"]
                ?.Value;
        }
