    using System.Diagnostics;
    public class Program
    {
    public static void Main() {
            Process.Start(@"c:\program files\windows azure sdk\v1.5\bin\csrun", "/devstore").WaitForExit();
        }
    }
