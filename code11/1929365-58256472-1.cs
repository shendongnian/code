    static void Test()
    {
      categorySource.Add(new CategorySource { Id = 1, Name = "Test 1" });
      categorySource.Add(new CategorySource { Id = 2, Name = "Test 2" });
      categorySource.Add(new CategorySource { Id = 3, Name = "Test 3" });
      categorySource.Add(new CategorySource { Id = 4, Name = "Test 4" });
      categorySource2.AddRange(categorySource);
      foreach ( var item in categorySource2 )
        Console.WriteLine($"{item.Id}: {item.Name}");
    }
    public static List<CategorySource> categorySource = new List<CategorySource>();
    public static List<CategorySource2> categorySource2 = new List<CategorySource2>();
    public class CategorySource2
    {
      public int Id { get; set; }
      public int GroupId { get; set; }
      public string Name { get; set; }
    }
    public class CategorySource : CategorySource2
    {
      public int SortOrder { get; set; }
    }
