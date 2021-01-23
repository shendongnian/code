    public class User : DbClass<User>
    {
        public Int32 Key { get; private set;}
        public String FirstName { get; set;}
        public String LastName { get; set;}
        protected override String FetchQuery
        { get { return "SELECT * FROM USER WHERE KEY = {0}";} }
        protected override void Initialize(DatabaseRecord row)
        {
            this.Key = DatabaseSession.SafeGetInt(row.GetField("KEY"));
            this.FirstName = DatabaseSession.SafeGetString(row.GetField("FIRST_NAME"));
            this.LastName = DatabaseSession.SafeGetString(row.GetField("LAST_NAME"));
        }
    }
