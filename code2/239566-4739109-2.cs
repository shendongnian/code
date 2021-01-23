        public static class RepositoryFactory
        {
            public static bool ConnectionStringIsReadOnly(string connectionString)
            {
                return connectionString.Contains("user=hacker");
            }
            public static IRead GetReadOnlyRepository(string connectionString)
            {
                return new Repository(connectionString);
            }
            public static IRepository GetRepository(string connectionString)
            {
                if (ConnectionStringIsReadOnly(connectionString)) throw new ArgumentException(@"Given connectionString is not allowed full repository access", "connectionString");
                return new Repository(connectionString);
            }
        }
