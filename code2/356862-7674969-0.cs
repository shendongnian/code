    public class Program {
      private static void Main(string[] args) {
        Func<IEnumerable, IEnumerable> testQuery = x => x.Where<IEnumerable>(y => !y.Equals("Yucky");
        var testArray=new string[] {"Hello", "Yuck", " ", "World"};
        
        var testClass=new MyClass(testQuery);
        var resultStrings = testClass.query(testArray);
        // Printing resultStrings should result in "Hello World"
        foreach (string s in resultStrings) {
           System.out.print(s);
        }
       }
    }
    
    
    public class MyClass {
      public Func<IEnumerable, IEnumerable> query { get; private set; }
      
      public MyClass(Func<IEnumerable, IEnumerable> aQuery)
      {
        query=aQuery;
      }
    }
