    public class MyGrouping {
      public string Key {get; internal set;}
    }
    
    list.ItemsSource=db.Templates.GroupBy(t=>t.CategoryName)
                                 .Select(g => new MyGrouping() { Key = g.Key });
