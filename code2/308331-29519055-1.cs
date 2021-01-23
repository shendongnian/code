    using System;
    using System.Web.Hosting;
    
    public class AppDomainUnveiler : MarshalByRefObject
    {
        public AppDomain GetAppDomain()
        {
            return AppDomain.CurrentDomain;
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var appDomain = ((AppDomainUnveiler)ApplicationHost.CreateApplicationHost(
                typeof(AppDomainUnveiler),
                "/",
                Path.GetFullPath("../Path/To/WebAppRoot"))).GetAppDomain();
            try
            {
                appDomain.DoCallback(TestHarness);
            }
            finally
            {
                AppDomain.Unload(appDomain);
            }
        }
    
        static void TestHarness()
        {
            //…
        }
    }
