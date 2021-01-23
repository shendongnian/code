    public class Foo
    {
       public static int[] Numbers {get; set;}
    }
    
    public class Bar
    {
       public int[] Numbers {get;set;}
    }
    
    public class Program
    {
         public void Main()
         {
    // NOTE: Foo itself has this array
              Foo.Numbers = new int[]{1,2,3};
    
    // NOTE: it's this particular instance of a Bar that has this array
               Bar bar = new Bar();
               bar.Numbers = new int[]{1,2,3};
    
         }
    }
