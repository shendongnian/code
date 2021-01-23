    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Threading.Tasks;
    using ExceptionFilter;
    
    class Program
    {
        static void Main()
        {
            new Task(new Action(TestCrash).CrashFilter()).RunSynchronously();
        }
    
        static void TestCrash()
        {
            try
            {
                new WebClient().DownloadData("http://filenoexist");
            }
            catch (WebException)
            {
                Debug.WriteLine("Caught a WebException!");
            }
            throw new InvalidOperationException("test");
        }
    }
