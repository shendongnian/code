    internal abstract class A
    {
      public void DoSomething(int ID)
      { 
         if(IsInRange(ID))
           DoSomethingProtected(ID);
      }
    
      protected abstract bool IsInRange(int ID);
    
      protected abstract void DoSomethingProtected(int ID);
    }
    
    
    internal class B : A
    {
      private List<int> firstRange = new List<int> { 42, 23, 5};
      protected override bool IsInRange(int ID)
      {
         return firstRange.Contains(ID); 
      }
      protected override void DoSomethingProtected(int ID)
      {
        Console.WriteLine("{0}", ID);
      } 
    }
    
    
    public class Program
    {
      public static void Main(string[] args)
      {
         B foo = new B();
         foo.DoSomething(3);
         foo.DoSomething(42);
      }
    }
