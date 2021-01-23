    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace YourNameSpaceGoesHere
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                            
                if (Process.GetProcessesByName("YourFriendlyProcessNameGoesHere").Length > 1)
                {
                    MessageBox.Show(Application.ProductName + " already running!");
                    Application.ExitThread();
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new YourStartUpObjectFormNameGoesHere());
                }
    
            }
        }
    }
