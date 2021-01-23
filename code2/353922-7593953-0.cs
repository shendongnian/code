    public interface IMyInterface{
     IList<string> SomeList { get; }
    }
    
    public class MyClass : IMyInterface {
      public IList<string> SomeList {
        get { 
          return new List<string>(){ "a", "b" , "c" }; 
        }
      }
    }
