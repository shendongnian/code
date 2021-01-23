    public class Something2
    {
      public IEnumerable<string> SomeValues { get; set; }
    }
    var dbQuery = BuildQuery("select item from inventory where item.Price > 5.00");
    var something = new Something();
    something.SomeValues = dbQuery.Evaluate(); // Imagine if this did paging...
