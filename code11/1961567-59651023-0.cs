    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    
    namespace EnumChildWinTest
    {
        public partial class Form1 : Form
        {
            public IntPtr windowHandle = IntPtr.Zero;      // Default value
    
            public Form1()
            {
                InitializeComponent();
            }
    
            [DllImport("user32.dll")] private static extern int GetWindowText(int hWnd, StringBuilder title, int size);
            StringBuilder title = new StringBuilder(256);
    
    
            // Go Button
            private void button1_Click(object sender, EventArgs e)
            {
    
    
                textBox1.Clear();
                textBox1.AppendText($"Window Handle: {GetWindowHandle(textBox2.Text)} {Environment.NewLine}");
    
                foreach (var child in GetChildWindows(windowHandle))
                {
                    textBox1.AppendText($"Child window: {child.ToString()} {Environment.NewLine}");
                    GetWindowText(child.ToInt32(), title, 256);
                    textBox1.AppendText($"Title:{title}{Environment.NewLine}");
                }
            }
    
            public IntPtr GetWindowHandle(string processName)
            {
    
                Process[] processes = Process.GetProcessesByName(processName);
    
                foreach (Process p in processes)
                {
                    windowHandle = p.MainWindowHandle;
                }
    
                return windowHandle;
            }
    
            public List<IntPtr> GetChildWindows(IntPtr handle)
            {
                var allChildWindows = new WindowHandleInfo(windowHandle).GetAllChildHandles();
    
                return allChildWindows;
            }
        }
    }
    
    public class WindowHandleInfo
    {
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);
    
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);
    
        private IntPtr _MainHandle;
    
        public WindowHandleInfo(IntPtr handle)
        {
            this._MainHandle = handle;
        }
    
        public List<IntPtr> GetAllChildHandles()
        {
            List<IntPtr> childHandles = new List<IntPtr>();
    
            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);
    
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(this._MainHandle, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }
    
            return childHandles;
        }
    
        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);
    
            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }
    
            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(hWnd);
    
            return true;
        }
    }
