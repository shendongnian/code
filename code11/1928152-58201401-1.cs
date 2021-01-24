    static void Test()
    {
      // Test data
      var ListOfList = new List<List<Product>>();
      var list1 = new List<Product>();
      list1.Add(new Product { name = "item 1", factor = 1, cost = 10 });
      list1.Add(new Product { name = "item 2", factor = 5, cost = 20 });
      var list2 = new List<Product>();
      list2.Add(new Product { name = "item 3", factor = 30, cost = 50 });
      list2.Add(new Product { name = "item 4", factor = 4, cost = 40 });
      var list3 = new List<Product>();
      list3.Add(new Product { name = "item 5", factor = 2, cost = 100 });
      list3.Add(new Product { name = "item 6", factor = 3, cost = 150 });
      var list4 = new List<Product>();
      list4.Add(new Product { name = "item 5", factor = 2, cost = 60 });
      list4.Add(new Product { name = "item 6", factor = 3, cost = 5 });
      ListOfList.Add(list1);
      ListOfList.Add(list2);
      ListOfList.Add(list3);
      ListOfList.Add(list4);
      // Query
      var query = ( from list in ListOfList
                    where list.Sum(x => x.factor) <= 10
                    orderby list.Sum(x => x.cost) descending
                    select list ).FirstOrDefault();
      // Display results
      if ( query != null )
        foreach ( var item in query )
          Console.WriteLine($"{item.name} cost {item.cost} with factor {item.factor}");
    }
    class Product
    {
      public string name;
      public int factor;
      public int cost;
    }
