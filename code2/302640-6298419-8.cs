    public class Program
    {
       public static void Main(
       {
          var kernel = new StandardKernel(MyNinjectModules);
          var myGenerator =    kernel.Get<Generator>();
       }
    
    
    }
