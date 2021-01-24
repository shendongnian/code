    public class CallingExe
    {
       public static void main(string[] args)
       {
          System.Diagnostics.Process.Start("CalledExe.exe", new string[] {1 , 2});
       }
    }
