    public interface IAbcId {
        Id {get; set;}
    }
    
    public class Abc : IAbcId {
        public Id {get; set;}
        public Name {get; set;}
    }
    
    ....
    
    public class Consumer {
    
       void CallingFunction()
       {
          var obj = new Abc();
          // obj will have Name and Id properties visible here
          ConsumingFunction(obj)
          // or
          IAbcId iAbc = new Abc();
          //iAbc.Name will not be visible here
       }
    
       void ConsumingFunction ( IAbcId item )
       {
           // item will only have Id property visible.
       }
    
    }
