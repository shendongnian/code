class Program
{
    static void Main(string[] args)
    {
       Parallel.For(0, 10, i =>
       {
          using(DbContextClass db = new DbContextClass()) {
               Category ct = new Category
               {
                    NameCategory = "SomeText"                           
               };
               db.Categories.Add(ct);
               db.SaveChanges();
          }
      });                           
       
      Console.ReadKey();
    }
}
  [1]: https://github.com/dotnet/efcore/issues/5962
