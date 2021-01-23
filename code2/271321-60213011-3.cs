using System;
using System.Diagnostics;
namespace ConsoleApplication
{
    class Program
    { 
        static void Main(string[] args)
        {
         System.Diagnostics.Process.Start(@"c:\batchfilename.bat", "\"1st\" \"2nd\"");
        }
    }
}
_ _ _ 
> Option 2 : Hiding the console window, passing arguments and taking outputs
_ _ _
using System;
using System.Diagnostics;
namespace ConsoleApplication
{
    class Program
    { 
	    static void Main(string[] args)
        {
         var process = new Process();
         var startinfo = new ProcessStartInfo(@"c:\batchfilename.bat", "\"1st_arg\" \"2nd_arg\" \"3rd_arg\"");
         startinfo.RedirectStandardOutput = true;
         startinfo.UseShellExecute = false;
         process.StartInfo = startinfo;
         process.OutputDataReceived += (sender, argsx) => Console.WriteLine(argsx.Data); // do whatever processing you need to do in this handler
         process.Start();
         process.BeginOutputReadLine();
         process.WaitForExit();
        }
    }
}
_ _ _ 
[1]: https://stackoverflow.com/questions/60207122/passing-arguments-to-a-cmd-file-in-c-sharp/60211584#60211584
[2]: https://stackoverflow.com/a/3742287/8177207
[3]: https://stackoverflow.com/users/6097430/janatbek-sharsheyev
[4]: https://stackoverflow.com/users/38206/brian-rasmussen
