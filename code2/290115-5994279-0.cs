    public class C1
    {
      public int x = 1;
    }
    
    public class C2
    {
      private C1 otherClass;
      // constructor
      public C2(C1 other)
      {
        this.otherClass = other;
      }
    
      public void accessOtherClass()
      {
        Console.WriteLine(this.otherClass.x);
      }
    }
