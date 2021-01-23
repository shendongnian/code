    public class OverlayDatabase
    {
        private string masterDbConnStr;
        private string userDbConnStr;
        public OverlayDatabase(string masterDbConnStr, string userDbConnStr)
        {
            // ...
        }
        public DataSet ExecuteQuery(DbCommand command)
        {
            var dataSets = new List<DataSet>();
            foreach (var connStr in new[] { masterDbConnStr, userDbConnStr } )
            {
                // 1. Create connection
                // 2. Execute command with that connection
                // 3. Store dataset in dataSets
            }
            return MergeDataSets(dataSets);
        }
        private DataSet MergeDataSets(IEnumerable<DataSet> datasets)
        {
            // Merge logic here
        }
    }
