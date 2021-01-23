    public class Something2
    {
      public List<string> SomeValues { get; set; }
    }
    var dbQuery = BuildQuery("select item from inventory where item.Price > 5.00");
    var something = new Something();
    something.SomeValues = dbQuery.Evaluate().ToList(); // Has to evaluate all of them...
