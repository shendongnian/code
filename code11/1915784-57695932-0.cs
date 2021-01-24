    using System;
    using System.Runtime.ExceptionServices;
    
        class Example
        {
            static void Main()
            {
                AppDomain.CurrentDomain.FirstChanceException += 
                    (object source, FirstChanceExceptionEventArgs e) =>
                    {
                        Console.WriteLine("FirstChanceException event raised in {0}: {1}",
                            AppDomain.CurrentDomain.FriendlyName, e.Exception.Message);
                    };
