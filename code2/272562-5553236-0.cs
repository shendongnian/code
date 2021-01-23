    public class Migration
    {
        private string _migrationPath = @"C:\temp\MigrationSteps"; //change
        private string[] _sqlFiles = null;
        public Migration()
        {
            Initialize();
        }
        public Migration(string path)
        {
            _migrationPath = path;
            Initialize();
        }
        private void Initialize()
        {
            _sqlFiles = Directory.GetFiles(_migrationPath, "*.sql");
        }
        public bool Run()
        {
            bool success = true;
            foreach (string sqlFile in _sqlFiles)
            {
                ExecuteRun(File.ReadAllText(sqlFile));
            }
            return success; //Do something with this value
        }
        public bool CleanUp()
        {
            //Put some logic here to "clean up" files that have already been run.
            throw new NotImplementedException();
        }
        private bool ExecuteRun(string sqlText)
        {
            //Call your data access library and execute the sqlText
            throw new NotImplementedException();
        }
    }
