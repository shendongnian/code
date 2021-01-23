    public class Program {
      private static void Main(string[] args) {
        Func<List<string>, IEnumerable> testQuery = x => x.Where<IEnumerable>(y => !y.Equals("Yucky"));
        var testArray=new string[] {"Hello", "Yucky", " ", "World"};
        
        var testClass=new MyClass(testQuery);
        var resultStrings = testClass.query(testArray.ToList());
        // Printing resultStrings should result in "Hello World"
        foreach (string s in resultStrings) {
           Console.Write(s);
        }
       }
    }
    
    
    public class MyClass {
      public Func<List<string>, IEnumerable> query { get; private set; }
      
      public MyClass(Func<List<string>, IEnumerable> aQuery)
      {
        query=aQuery;
      }
    }
