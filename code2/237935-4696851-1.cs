    public struct MyStruct
    {
         public string Name;
         public bool Process;
    }    
    
    public void LinqCellenge()
    {
       var sourceList = Enumerable.Empty<MyStruct>();
        
        var resultList = sourceList
          .GroupBy(item => item.Name, (name, values) => new MyStruct()
            {
              Name = name,
              Flag = values.All(x => x.Flag)
            });
    }
