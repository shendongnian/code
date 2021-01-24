    public class CallingExe
    {
       public static void main(string[] args)
       {
          System.Diagnostics.Process proc = new System.Diagnostics.Process();
          proc.StartInfo.FileName = @"CalledExe.exe";
          proc.StartInfo.Arguments = "1 2";
          proc.Start();
       }
    }
