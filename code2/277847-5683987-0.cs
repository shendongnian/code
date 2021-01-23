    public interface IMyInterface
    {
      void PerformOperation();
    }
    
    public class MyGeneric<T> : IMyInterface
    {
      T Value {get;set;}
      MyGeneric(T val) 
      {
        Value = val;
      }
      void PerformOperation 
      { 
         Console.WriteLine("T is {0}", typeof(T));
         Console.WriteLine("Value is {0}", Value);
      }
    }
    
    public void main(string[] args)
    {
       IMyInterface inst = null;
       switch (args[0])
       {
        case "string":
           inst = new MyGeneric("hello");
           break;
        case "int":
            inst = new MyGeneric(7);
            break;
        case "decimal"
            inst = new MyGeneric(18.9M);
            break;
        }
    
       inst.PerformOperation();
    }
