    public class _A<T> where T : _A<T> {
      public static int[] Values=new int[] {1,2};
      public static void Foo() {
        Console.WriteLine(String.Format("Foo called in class: {0} {1}",typeof(T).Name, String.Join(",",T.Values)));
      }
    }
    public class A : _A<A> {
    }
    public class B : _A<B> {
      public static new int[] Values=new int[] {1,2,3};
    }
    public class C : _A<C> {
      public static new int[] Values=new int[] {1,2,3,4,5};
    }
