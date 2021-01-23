    using System;
    using System.Reflection;
    namespace BitnessTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
                if (IntPtr.Size > 4)
                {
                    setup.PrivateBinPath = "x64";
                }
                else
                {
                    setup.PrivateBinPath = "x86";
                }            
                AppDomain appDomain = AppDomain.CreateDomain("Real Domain", null, setup);
                appDomain.DoCallBack(StartClass.Start);
            }
        }
    }
