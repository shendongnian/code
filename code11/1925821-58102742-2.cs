    public class InformationGetter {
        public string ConnectionString { get; set; }
        public string StoredProcedureName { get; set; }
        //...
        public string GetUserInformation(int userId) {
            // Do SQL work
            return info;
        }
    }
