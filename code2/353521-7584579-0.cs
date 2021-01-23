    public class Foo
    {
       public int ID { get; set; }
       public sring Name { get; set; }
       public DateTime Date { get; set;
    }
    public class FooDataContext : DbContext
    {
       IDbSet<Foo> Foos { get; set; }
    }
    using (var context = new FooDataContext())
    {
         List<Foo> foos = context.Foos.ToList();
    }
