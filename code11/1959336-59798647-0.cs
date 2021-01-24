    using Abp;
    using Abp.Castle.Logging.Log4Net;
    using Abp.Dependency;
    using Castle.Facilities.Logging;
    using System;
    
    namespace MYNAMESPACE
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Bootstrapping ABP system
                using (var bootstrapper = AbpBootstrapper.Create<MYMODULE>())
                {
                    IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig("log.config"));
                    bootstrapper.Initialize();
                    Console.WriteLine("Press enter to exit...");
                    Console.ReadLine();
                }
                Console.ReadLine();
            }
        }
    }
