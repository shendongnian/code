    using System;
    using System.Windows.Forms;
    
    namespace WindowsConsole
    {
        public partial class Form1 : Form
        {
            System.Diagnostics.Process spdTerminal;
            System.IO.StreamWriter swInputStream;
    
    
            public delegate void fpTextBoxCallback_t(string strText);
            public fpTextBoxCallback_t fpTextBoxCallback;
    
            public Form1()
            {
                fpTextBoxCallback = new fpTextBoxCallback_t(AddTextToOutputTextBox);
                InitializeComponent();
            }
    
    
            public void AddTextToOutputTextBox(string strText)
            {
                this.txtOutput.AppendText(strText);
            }
            
            
            private void btnQuit_Click(object sender, EventArgs e)
            {
                swInputStream.WriteLine("exit");
                swInputStream.Close();
                //spdTerminal.WaitForExit();
                spdTerminal.Close();
                spdTerminal.Dispose();
                Application.Exit();
            }
    
    
            private void ConsoleOutputHandler(object sendingProcess, System.Diagnostics.DataReceivedEventArgs outLine)
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    //this.Invoke(new fpTextBoxCallback_t(AddTextToOutputTextBox), Environment.NewLine + outLine.Data);
                    if(this.InvokeRequired)
                        this.Invoke(fpTextBoxCallback, Environment.NewLine + outLine.Data);
                    else
                        fpTextBoxCallback(Environment.NewLine + outLine.Data);
                }
            }
    
    
            private void btnExecute_Click(object sender, EventArgs e)
            {
                if (this.spdTerminal.HasExited)
                    MessageBox.Show("You idiot, you have terminated the process", "Error");
                swInputStream.WriteLine(txtInputCommand.Text);
            }
    
    
    
            public void ProcessExited(object sender, EventArgs e)
            {
                MessageBox.Show("You idiot, you terminated the process.", "PBKAC");
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                spdTerminal = new System.Diagnostics.Process();
    
                spdTerminal.StartInfo.FileName = "cmd.exe";
                spdTerminal.StartInfo.UseShellExecute = false;
                spdTerminal.StartInfo.CreateNoWindow = true;
                spdTerminal.StartInfo.RedirectStandardInput = true;
                spdTerminal.StartInfo.RedirectStandardOutput = true;
                spdTerminal.StartInfo.RedirectStandardError = true;
    
                spdTerminal.EnableRaisingEvents = true;
                spdTerminal.Exited += new EventHandler(ProcessExited);
                spdTerminal.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);
                spdTerminal.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);
                
                spdTerminal.Start();
    
                swInputStream = spdTerminal.StandardInput;
                spdTerminal.BeginOutputReadLine();
                spdTerminal.BeginErrorReadLine();
            }
    
    
        }
    
    
    }
