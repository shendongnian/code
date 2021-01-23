    public class Foo
    {
       public int ID { get; set; }
       public sring Name { get; set; }
       public DateTime Date { get; set;
    }
    public class Bar
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public List<DateTime> Dates { get; set; }
    }
    public class FooDataContext : DbContext
    {
       IDbSet<Foo> Foos { get; set; }
    }
    using (var context = new FooDataContext())
    {
         List<Bar> bars = context.Foos
                                 .GroupBy( f => new { f.ID, f.Name } )
                                 .Select( g => new Bar
                                  {
                                      ID = g.Key.ID,
                                      Name = g.Key.Name,
                                      Dates = g.Select( f => f.Date )
                                  });
    }
