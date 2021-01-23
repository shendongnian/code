        Repository repository;
        // Default Contructor
        public MyController()
        {
            repository = new Repository();
        }
        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
        }
