    public class MyDatabse : DataContext
    {
        public Table<Bookss> Bookss;
        public MyDatabse(string connection) : base(connection) { }
    }
    [Table(Name = "Books")]
    public class Bookss
    {
        [Column(IsPrimaryKey = true)]
        public string Title;
        [Column]
        public string Rating;
    }
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase("DynamicDatabase11");
        }
        public static void CreateDatabase(string Dbname )
        {
            
            MyDatabse db = new MyDatabse("ConString"+Dbname+"");
            db.CreateDatabase();
        }
        
    }
}
