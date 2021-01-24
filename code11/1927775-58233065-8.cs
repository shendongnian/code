    using System.Collections.Generic;
    public class ElementWindow
    {
        public ElementWindow(string processName) => this.ProcessName = processName;
        public string ProcessName { get; set; }
        public string MainWindowTitle { get; set; }
        public int ProcessId { get; set; }
        public IntPtr MainWindowHandle { get; set; }
    }
