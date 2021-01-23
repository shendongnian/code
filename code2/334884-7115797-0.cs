    public class A {
    
      protected int[] values;
    
      public A () {
        values = new int[] { 1, 2 };
      }
    
      public void Foo() {
        Console.WriteLine("Foo called in class: {0}, values = {1}", this.GetType().Name, String.Join(",", values));
      }
    
      public static void Bar() {
        Console.WriteLine("Same for all classes.");
      }
    
    }
    
    public class B : A {
    
      public B () {
        values = new int[] { 1, 2, 3 };
      }
    
    }
    
    public class C : A {
    
      public C () {
        values = new int[] { 1, 2, 3, 4, 5 };
      }
    
    }
