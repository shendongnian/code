    class Program
    {
       class MyArrayType
       {
         public int MyInt { get; set; }
         public string Test { get; set; }
         public string Comment1 { get; set; }
         public string Comment2 { get; set; }
         public string Comment3 { get; set; }
    
       }
    
      static void Main()
      {
    
        List<MyArrayType> list = new List<MyArrayType>();
        list.Add(new MyArrayType { MyInt = 1, Test = "test1", Comment1 = "Comment1", Comment2 = "Comment3", Comment3 = "Comment3" });
        // so on
    
        list[15].MyInt = 15;
        list[15].Comment1 = "Comment";
        // so on
      }
      
    }
