    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = false;
        }
        private void ButtonRunProcess_Click(object sender, EventArgs e) {
            var ProcessObj = new Process();
            ProcessObj.SynchronizingObject = this;
            ProcessObj.EnableRaisingEvents = true;
            ProcessObj.Exited += new EventHandler(ProcessObj_Exited);
            ProcessObj.StartInfo.FileName = @"c:\windows\notepad.exe";
            // etc...
            ProcessObj.Start();
            progressBar1.Visible = true;
        }
        void ProcessObj_Exited(object sender, EventArgs e) {
            progressBar1.Visible = false;
        }
    }
