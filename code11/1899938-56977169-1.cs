cs
public class ExitCodeUsage
{
   public static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length == 1) {
         Environment.ExitCode = -1;  
      }
      else {
         //Do stuff that requires the length of args to be not equal to 1.
      }
   }
}
cs
public class ExitUsage
{
   public static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length == 1) {
         Environment.Exit(-1);  
      }
      //Do stuff that requires the length of args to be not equal to 1.
      
   }
}
