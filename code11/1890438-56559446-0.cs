    class Test1
    {
         public int ID { get; set; }
         public string Name { get; set; }
    }
        
    class Test2
    {
          public int ID { get; set; }
          public string Name { get; set; }
    }
    
    var test1Lst = new List<Test1>
    {
          new Test1() { ID = 1, Name = "Jitendra" },
          new Test1() { ID = 2, Name = "Jahnavi" }
    };
        
    var test2Lst = new List<Test2>
    {
          new Test2() { ID = 1, Name = "Aaditri" },
          new Test2() { ID = 2, Name = "Pankaj" }
    };
    
    var test = false;
    var query = test ? (from t in test1Lst select new { ID = t.ID, Name = t.Name }) : (from t in test2Lst select new { ID = t.ID, Name = t.Name });
     
    // Put whatever condition you want to put here   
    query = query.Where(x => x.ID == 1);
        
    foreach(var t1 in query)
    {
          Console.WriteLine(t1.ID + " " + t1.Name);
    }
