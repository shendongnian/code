    using System;
    using System.Diagnostics;
    using System.Windows.Automation;
    
    namespace ConsoleApplication2 {
        class Program {
            static void Main(string[] args) {
                // Kill existing instances
                foreach (Process pOld in Process.GetProcessesByName("taskmgr")) {
                    pOld.Kill();
                }
    
                // Create a new instance
                Process p = Process.Start("taskmgr");
                Console.WriteLine("Waiting for handle...");
    
                // Hackish way to wait for program to load
                // In a production version, please improve this!
                while (p.MainWindowHandle == IntPtr.Zero) ;
    
                AutomationElement aeDesktop = AutomationElement.RootElement;
                AutomationElement aeForm = AutomationElement.FromHandle(p.MainWindowHandle);
                Console.WriteLine("Got handle");
    
                // Get the tabs control
                AutomationElement aeTabs = aeForm.FindFirst(TreeScope.Children,
      new PropertyCondition(AutomationElement.ControlTypeProperty,
        ControlType.Tab));
    
                // Get a collection of tab pages
                AutomationElementCollection aeTabItems = aeTabs.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty,
        ControlType.TabItem));
    
                // Set focus to the performance tab
                AutomationElement aePerformanceTab = aeTabItems[3];
                aePerformanceTab.SetFocus();
            }
        }
    }
