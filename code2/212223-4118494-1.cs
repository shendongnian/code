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
                swInputStream.WriteLine(txtInputCommand.Text);
            }
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                spdTerminal = new System.Diagnostics.Process();
    
                spdTerminal.StartInfo.FileName = "cmd.exe";
                spdTerminal.StartInfo.UseShellExecute = false;
                spdTerminal.StartInfo.CreateNoWindow = true;
                spdTerminal.StartInfo.RedirectStandardOutput = true;
    
                spdTerminal.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);
                spdTerminal.StartInfo.RedirectStandardInput = true;
                spdTerminal.Start();
    
                swInputStream = spdTerminal.StandardInput;
                spdTerminal.BeginOutputReadLine();
            }
    
    
        }
    
    
    }
