        public static class DAL 
        {
            // repo factory is pretty lightweight, so no need for fancy
            // singleton patterns
            private static readonly IRepoFactory _repoFactory = new RepoFactory();
            public static IRepoFactory RepoFactory
            { 
                get { return _repoFactory; }
            }
        }
