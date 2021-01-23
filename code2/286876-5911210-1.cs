     public class A
     {
         private int aa;
     }
     public class B
     {
         private int bb;
     }
    System.Reflection.FieldInfo[] fields = (new B()).GetType().GetFields(BindingFlags.NonPublic| BindingFlags.Public | BindingFlags.Instance);
