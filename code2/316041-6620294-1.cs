    public class Foo
    {
        public Foo() { }
        public string FooString { get; set; }
        public int FooInt { get; set; }
    }
    class Program
    {
        public static List<Foo> GetFooList(string connectionString, string cmdText)
        {
            OdbcQuery query = new OdbcQuery(new OdbcConnection(connectionString), cmdText);
            List<Foo> fooList = query.Transform(
                rdr =>
                {
                    Foo foo = new Foo();
                    foo.FooInt = rdr.GetInt32(0);
                    foo.FooString = rdr.GetString(1); 
                    return foo; 
                });
            return fooList; 
        }
