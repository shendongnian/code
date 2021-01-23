     public static void Insert(MyDataContext db, ISession item) 
     {
         // GetTable is defined by Linq2Sql
         db.GetTable(GetRowType(domain)).InsertOnSubmit(item);
     }
