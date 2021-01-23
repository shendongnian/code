    const string _myGuidStr = "e6b86ea3-6479-48a2-b8d4-54bd6cbbdbc5";
    
    
    public static class RecordTypeIds
    {
        public const string USERS_TYPEID = "5C60F693-BEF5-E011-A485-80EE7300C695";
        public static Guid Users { get { return new Guid(EntityTypeIds.USERS_TYPEID); } }
    }
    
    
    public static readonly Guid Users = new Guid("5C60F693-BEF5-E011-A485-80EE7300C695");
