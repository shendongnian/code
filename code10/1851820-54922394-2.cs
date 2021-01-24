     public class MyClass {
       public MyClass(string nameDisplay, int count) {
         NameDisplay = nameDisplay;
         Count = count;
       }
       public string NameDisplay {get; private set;} 
       public int Count {get; private set;}
     } 
     ...
     
     public IEnumerable<MyClass> TestL() {
       return TestList
         .GroupBy(s => s.Postion.ToUpper())
         .Select(chunk => new MyClass(d.Key, d.Count()))
         .OrderBy(item => item.NameDisplay); 
     }
