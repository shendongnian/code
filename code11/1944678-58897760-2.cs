    public class ClassA {
      public virtual void MethodA() {
        Console.WriteLine("ClassA.MethodA");
      }
    
      public virtual void MethodB(){
        Console.WriteLine("ClassA.MethodB");
      }
    }
    public class ClassC: ClassA {
      public void MethodC() {
        Console.WriteLine("ClassC.MethodC");
      }
    }
