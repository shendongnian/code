    interface IDataEntity {
        void Load(SqlDataReader reader);
        string ConnectionString {get;set;}
    }
    class Customer : IDataEntity 
    { ... }
