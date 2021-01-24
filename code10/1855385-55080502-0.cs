    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    namespace DeploymentPreparer
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                string option = args[0];
                switch (option)
                {
                    case "WPF":
                        RunApplication();
                        break;
                    default:
                        DoSomething();
                        break;
                }
            }
            private static void RunApplication()
            {
                ShowWindow(GetConsoleWindow(), SW_HIDE);
                Application app = new Application();
                app.Run(new MainWindow());
            }
            private static void DoSomething()
            {
                // ...
            }
            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            const int SW_HIDE = 0;
            const int SW_SHOW = 5;
        }
    }
