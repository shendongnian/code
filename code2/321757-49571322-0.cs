    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    namespace MyProcessSample
    {
        class MyProcess
        {
            public static void Main()
            {
                Process myProcess = new Process();
                myProcess.Start("chrome.exe","http://www.com/newfile.zip");
            }
        }
    }
