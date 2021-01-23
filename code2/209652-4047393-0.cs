    using System;
    using System.Threading;
    using System.IO;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                string exePath = @"c:\projects\consoleapplication2\bin\debug\consoleapplication2.exe";
                for (int ix = 0; ix < 10; ++ix) {
                    var setup = new AppDomainSetup();
                    setup.ApplicationBase = Path.GetDirectoryName(exePath);
                    var ad = AppDomain.CreateDomain(string.Format("Domain #{0}", ix + 1), null, setup);
                    var t = new Thread(() => {
                        ad.ExecuteAssembly(exePath);
                        AppDomain.Unload(ad);
                    });
                    t.Start();
                }
                Console.ReadLine();
            }
        }
    }
