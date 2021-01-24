    public class SqlScriptRunner
    {
        private IDbContext _context;
        private readonly IHostingEnvironment _hosting;
        private string _directory;
        public SqlScriptRunner(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }
        public IDbContext Context
        {
            set => _context = value;
        }
        /// <summary>
        /// Name of the directory containing json seed data e.g. Data\Store
        /// </summary>
        public string Directory
        {
            set => _directory = value;
        }
        public void ExecuteScripts()
        {
            if (_context == null) throw new NullReferenceException("Database context for SqlScriptRunner is null.");
            if (string.IsNullOrEmpty(_directory)) throw new NullReferenceException("SqlScriptRunner directory is null or empty.");
            var directoryInfo = new DirectoryInfo( Path.Combine(_hosting.ContentRootPath, _directory));
            foreach (var file in directoryInfo.GetFiles().OrderBy(f => f.FullName))
            {
                var script = File.ReadAllText(file.FullName);
                _context.Database.ExecuteSqlCommand(script);
            }
        }
    }
