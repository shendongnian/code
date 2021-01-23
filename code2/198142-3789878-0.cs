    public class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
    
        private void button1_Click(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName("notepad");
            if (process.Length > 0)
                SetForegroundWindow(process[0].MainWindowHandle);
        }
    }
