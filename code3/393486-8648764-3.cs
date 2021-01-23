    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                ProcessListModel processes = Program.GetProccesses();
                foreach (ProcessModel process in processes.Items)
                {
                    Console.WriteLine("Program: " 
                      + process.Filename 
                      + "[" + process.IsWindowsExplorer.ToString() + "]");
                    Console.WriteLine("- Window Text: " + process.WindowText);
                }
                Console.ReadKey();
            }
            [DllImport("user32")]
            public static extern int EnumWindows(EnumWindowsDelegate CallBack,
                                                 ProcessListModel Processes);
            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowThreadProcessId(int hWnd, 
              out int lpdwProcessId);
            [DllImport("user32")]
            internal static extern int GetAncestor(int hwnd, int gaFlags);
            [DllImport("user32")]
            internal static extern int GetLastActivePopup(int hWnd);
            [DllImport("user32")]
            internal static extern bool IsWindowVisible(int hWnd);
            [DllImport("User32.Dll")]
            public static extern void GetWindowText(int h, 
              StringBuilder s, 
              int nMaxCount);
            internal delegate bool EnumWindowsDelegate(int Hwnd, 
              ProcessListModel Processes);
            internal static bool EnumWindowsCallBack(int Hwnd, 
              ProcessListModel Processes)
            {
                ProcessModel model = new ProcessModel();
                // Visible != Minimized (I think) 
                if (!IsWindowVisible(Hwnd))
                    return true;
                // Can the Window be shown by using alt-tab 
                if (IsAltTabWindow(Hwnd))
                {
                    model.WindowsHandle = Hwnd;
                    try
                    {
                        int pid = 0;
                        Program.GetWindowThreadProcessId(Hwnd, out pid);
                        if (pid > 0)
                        {
                            try
                            {
                                model.ProcessID = pid;
                                Process p = Process.GetProcessById(pid);
                                if (p != null)
                                {
                                    string filename = p.MainModule.FileName;
                                    filename = System.IO.Path.GetFileName(filename);
                                    model.Filename = filename;
                                    StringBuilder windowText = new StringBuilder(256);
                                    Program.GetWindowText(Hwnd, windowText, 256);
                                    model.WindowText = windowText.ToString();
                                
                                    if (filename.Contains("explorer.exe"))
                                    {
                                        model.IsWindowsExplorer = true;
                                    }
                                    Processes.Items.Add(model);
                                }
                            }
                            // Do something or not,  
                            // catch probably if window process 
                            // is closed while querying info 
                            catch { }
                        }
                    }
                    // Do something or not,  
                    // catch probably if window process 
                    // is closed while querying info 
                    catch { }
                }
                return true;
            }
            internal static bool IsAltTabWindow(int hwnd)
            {
                // Start at the root owner 
                int hwndWalk = GetAncestor(hwnd, 3);
                // See if we are the last active visible popup 
                int hwndTry;
                while ((hwndTry = GetLastActivePopup(hwndWalk)) != hwndTry)
                {
                    if (IsWindowVisible(hwndTry))
                        break;
                    hwndWalk = hwndTry;
                }
                return hwndWalk == hwnd;
            }
            public static ProcessListModel GetProccesses() 
            {
              ProcessListModel processes = new ProcessListModel();
              EnumWindowsDelegate enumCallback = 
                new EnumWindowsDelegate(EnumWindowsCallBack); 
              EnumWindows(enumCallback, processes); 
              return processes; 
            }
            public class ProcessListModel
            {
                public ProcessListModel()
                {
                    this.Items = new List<ProcessModel>();
                }
                public List<ProcessModel> Items { get; private set; }
            }
            public class ProcessModel
            {
                public int WindowsHandle { get; set; }
                public int ProcessID { get; set; }
                public string Filename { get; set; }
                public bool IsWindowsExplorer { get; set; }
                public string WindowText { get; set; }
            }
        }
    }
