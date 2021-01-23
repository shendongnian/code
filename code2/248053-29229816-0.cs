    public class Example 
   `{
     public static void Main()`
        
         {
 
         Console.WriteLine("The version of the currently executing assembly is: {0}",
                typeof(Example).Assembly.GetName().Version);
         }
}
   
