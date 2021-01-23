    static void Main(string[] args)
    {           
       MyDatabase db = new MyDatabase(@"C:\Temp\Database.sdf");
       db.CreateDatabase();
    }
    
    public class MyDatabase : DataContext
    {
        public Table<Product> Products;
        public MyDatabase(string connection) : base(connection) { }
    }
    
    [Table(Name="Products")]
    public class Product
    {
        [Column(IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.OnInsert, Name="ProductId")]
        internal int ProductId{ get; set; }
    
        [Column (CanBeNull=false)]
        public string Name { get; set; }
    
        [Column (CanBeNull=false)]
        public DateTime CreatedDate { get; set; }
    
        [Column (CanBeNull=true)]
        public DateTime? ModifiedDate { get; set; }
    }
