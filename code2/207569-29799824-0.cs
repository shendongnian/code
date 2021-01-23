    using System;
    using DotNetBrowser;
    
    namespace MyNamespace
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Provide path to the directory with DotNetBrowser Chromium binaries.
                Environment.SetEnvironmentVariable("DOTNETBROWSER_BIN_DIR", @"D:\Library\Chromium");
                
                // Create Browser instance.
                Browser browser = BrowserFactory.Create();
                browser.LoadURL("http://www.google.com");
            }
        }
    }
