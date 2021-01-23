    public class A
    {
      public delegate void MoveDelegate(object o);
      public static MoveDelegate MoveMethod;
    }
  
    public class B
    {
      public static void MoveIt(object o)
      {
        // Do something
      }    
    }
  
    public class C
    {
      public void Assign()
      {
        A.MoveMethod = B.MoveIt;
      }
      public void DoSomething()
      {
        if (A.MoveMethod!=null)
          A.MoveMethod(new object()); 
      }
    }
