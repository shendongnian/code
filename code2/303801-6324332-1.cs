    using System;
    using System.Windows;
    using System.Windows.Forms;
    
    namespace Foo
    {
        public class WindowUtility
        {
            public static void MoveToMonitor(Window window, int monitorId, bool maximize)
            {
                Screen[] screens = Screen.AllScreens;
    
                int screenId = Convert.ToInt32(monitorId) - 1;
    
                if (screens.Length > 1 && screenId < screens.Length)
                {
                    var screen = screens[screenId];
                    var area = screen.WorkingArea;
    
                    if (maximize)
                    {
                        window.Left = area.Left;
                        window.Top = area.Top;
                        window.Width = area.Width;
                        window.Height = area.Height;
                    }
                    else
                    {
                        window.Left = area.Left;
                        window.Top = area.Top;
                    }
                }
            }
        }
    }
