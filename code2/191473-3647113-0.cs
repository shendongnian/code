    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool BringWindowToTop(IntPtr hWnd);
        private void OnClicked_PasteToNotepad(object sender, EventArgs e) {
            // Let's start Notepad
            Process process = new Process();
            process.StartInfo.FileName = "C:\\Windows\\Notepad.exe";
            process.Start();
            
            // Give the process some time to startup
            Thread.Sleep(10000);
            // Copy the text in the datafield to Clipboard
            Clipboard.SetText(uxData.Text, TextDataFormat.Text);
            // Get the Notepad Handle
            IntPtr hWnd = process.Handle;
            // Activate the Notepad Window
            BringWindowToTop(hWnd);
            // Use SendKeys to Paste
            SendKeys.Send("^V");
        }
    }
