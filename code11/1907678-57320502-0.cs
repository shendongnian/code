using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUApiLib;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var session = new UpdateSession();
            var searcher = session.CreateUpdateSearcher();
            searcher.Online = false;
            var result = searcher.Search("IsInstalled=1");
            Console.WriteLine($"Found {result.Updates.Count} installed updates");
            Console.Read();
        }
    }
}
(you'll need a reference to the COM library "WUAPI 2.0 Type Library" in the project)
The above example could be used to check if the number of installed updates has changed since it was last run.
Check the referenced documentation for the right query to use to suit you; for example, some updates may be hidden.
  [1]: https://docs.microsoft.com/en-us/windows/win32/wua_sdk/portal-client
