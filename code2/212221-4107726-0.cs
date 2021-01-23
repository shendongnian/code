    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            private static StringBuilder cmdOutput = null;
            Process cmdProcess;
            StreamWriter cmdStreamWriter;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                cmdOutput = new StringBuilder("");
                cmdProcess = new Process();
    
                cmdProcess.StartInfo.FileName = "cmd.exe";
                cmdProcess.StartInfo.UseShellExecute = false;
                cmdProcess.StartInfo.CreateNoWindow = true;
                cmdProcess.StartInfo.RedirectStandardOutput = true;
    
                cmdProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
                cmdProcess.StartInfo.RedirectStandardInput = true;
                cmdProcess.Start();
    
                cmdStreamWriter = cmdProcess.StandardInput;
                cmdProcess.BeginOutputReadLine();
            }
    
            private void btnExecute_Click(object sender, EventArgs e)
            {
                cmdStreamWriter.WriteLine(textBox2.Text);
            }
    
            private void btnQuit_Click(object sender, EventArgs e)
            {
                cmdStreamWriter.Close();
                cmdProcess.WaitForExit();
                cmdProcess.Close();
            }
    
            private void btnShowOutput_Click(object sender, EventArgs e)
            {
                textBox1.Text = cmdOutput.ToString();
            }
    
            private static void SortOutputHandler(object sendingProcess,
                DataReceivedEventArgs outLine)
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    cmdOutput.Append(Environment.NewLine + outLine.Data);
                }
            }
        }
    }
