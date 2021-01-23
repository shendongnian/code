    public interface ISession 
    {
        public DateTime CreateDt {get; set; }
        public string HostAddress {get; set; }
        public int SessionDuration {get; set; }
    }
    public static IQueryable<ISession> GetQueryableTable(MyDataContext db, string site)
    {
         Type itemType;
         switch (item) 
         {
            case "stackoverflow.com":
                itemType = typeof(Analytics_StackOverflow);
                break;
            case "serverfault.com":
                itemType = typeof(Analytics_ServerFault);
                break;
            default: throw Exception();
         }
         return db.GetTable(itemType).Cast<ISession>();
    }
