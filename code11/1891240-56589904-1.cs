    List<FullName> Names = new List<FullName>();
    for ( int i = 0; i < 10; i++ )
    {
         Names.Add(new FullName() { Name = "John", SurName = "Smith" });
    }
    Console.WriteLine(String.Join("\r\n", Names));
