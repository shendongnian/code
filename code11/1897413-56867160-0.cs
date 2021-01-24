DbContext.Effort.cs
    namespace blah.blah.blah
    {
         public partial class MyContext
         {
             public MyContext(DbConnection connection) 
                : base(connection, false)
             { }
         }
    }
