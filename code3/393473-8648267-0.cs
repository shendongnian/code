    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    using System.Globalization;
    namespace VSSWriterTest
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        public class VSSCommands
        {
            public string VSS_VSSExecutable = "vssadmin";
            public string VSS_VSSListWriters = " list writers";
        }
           
        private void Form1_Load(object sender, EventArgs e)
        {
            //close handler
            this.FormClosing+=new FormClosingEventHandler(Form1_FormClosing);
            
        }
        private void Form1_FormClosing(object sender, EventArgs e)
        {
        }
        //my thread and process vars
        private Process m_Process;
        private Thread m_OutputThread;
        private Thread m_ErrorThread;
        private string m_TextToAdd;
       //basic writer command line stuff
        public class WriterStats
        {
            public string WriterName = "Writer Name";
            public string WriterTD = "Writer Id";
            public string WriterInstanceId = "Writer Instance Id";
            public string WriterState = "State";
            public string WriterLastError = "Last error";
            public string NoError = "No error";
        }
        private void StartVSSDiagnostics()
        {
            try
            {
                this.rtbVSSList.Clear();
                iErrorCount = 0;
                iWriterCount = 0;
                this.txtErrors.Clear();
                //start cmd prompt, then write command statement to console screen
                if ((StartVSSDiagnosticsThreads()))
                {
                    VSSCommands ServiceCall = new VSSCommands();
                   
                    string msg = ServiceCall.VSS_VSSExecutable + ServiceCall.VSS_VSSListWriters;
                    VSSStreamInput(msg);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "EVAS Backup and Restore");
            }
        }
        private void VSSStreamInput(string Text)
        {
            try
            {
                if (Text != string.Empty)
                {
                    m_Process.StandardInput.WriteLine(Text);
                    m_Process.StandardInput.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private bool StartVSSDiagnosticsThreads()
        {
            try
            {
                //close threads if open
                CloseThreads();
                //start new cmd prompt thread
                m_Process = new Process();
                {
                    m_Process.StartInfo.FileName = "cmd";
                    m_Process.StartInfo.UseShellExecute = false;
                    m_Process.StartInfo.CreateNoWindow = true;
                    m_Process.StartInfo.RedirectStandardOutput = true;
                    m_Process.StartInfo.RedirectStandardError = true;
                    m_Process.StartInfo.RedirectStandardInput = true;
                    
                }
                m_Process.Start();
                //create the call backs
                m_OutputThread = new Thread(StreamOutput);
                m_OutputThread.IsBackground = true;
                m_OutputThread.Start();
                m_ErrorThread = new Thread(StreamError);
                m_ErrorThread.IsBackground = true;
                m_ErrorThread.Start();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //this stream is feedback from the command prompt, its a delegate thats on a seperate thread other than this UI
        private void StreamOutput()
        {
            try
            {
                string Line = m_Process.StandardOutput.ReadLine();
                while (Line.Length >= 0)
                {
                    if (Line.Length > 0)
                    {
                        ConsoleMessage(ConvertFromOem(Line));
                    }
                    Line = m_Process.StandardOutput.ReadLine();
                }
            }
            catch
            {
                //ConsoleMessage(String.Format("""{0}"" Error!", m_Process.StartInfo.FileName))
            }
        }
        //convert text encoding to readable characters
        private string ConvertFromOem(string Text)
        {
            try
            {
                return Encoding.GetEncoding(CultureInfo.InstalledUICulture.TextInfo.OEMCodePage).GetString(Encoding.Default.GetBytes(Text));
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        //stream error callback
        private void StreamError()
        {
            try
            {
                string Line = m_Process.StandardError.ReadLine();
                while (Line.Length >= 0)
                {
                    Line = m_Process.StandardError.ReadLine();
                    if (Line.Length > 0)
                    {
                        ConsoleMessage(Line, true);
                    }
                }
            }
            catch
            {
                //ConsoleMessage(String.Format("""{0}"" Error!", m_Process.StartInfo.FileName))
            }
        }
        //actual delegate that invokes the main thread
        private void ConsoleMessage(string Text, bool err = false)
        {
            try
            {
                if (err)
                {
                    m_TextToAdd = "ERROR: " + Text;
                }
                else
                {
                    m_TextToAdd = Text;
                }
                this.Invoke((MethodInvoker)this.RaiseConsoleTextEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //raise  text event, new text arrived from console
        private void RaiseConsoleTextEvent()
        {
            try
            {
                VSSMessages(m_TextToAdd);
               
            }
            catch (Exception ex)
            {
            }
        }
        //my message filter, what i want displayed on my UI, i parse microsoft logo and garbage to display results only
        private int iErrorCount = 0;
        private int iWriterCount = 0;
        private void VSSMessages(string e)
        {
            WriterStats IWriter = new WriterStats();
            if ((e.ToUpper().Contains(IWriter.WriterInstanceId.ToUpper()) | e.ToUpper().Contains(IWriter.WriterLastError.ToUpper()) |
                e.ToUpper().Contains(IWriter.WriterName.ToUpper()) | e.ToUpper().Contains(IWriter.WriterState.ToUpper()) |
                e.ToUpper().Contains(IWriter.WriterTD.ToUpper())))
            {
                if ((e.ToUpper().Contains(IWriter.WriterName.ToUpper())))
                {
                    iWriterCount += 1;
                    this.rtbVSSList.AppendText("Writer (" + iWriterCount.ToString() + ") " + e + Environment.NewLine);
                }
                else
                {
                    this.rtbVSSList.AppendText(e + Environment.NewLine);
                }
                if ((e.ToUpper().Contains(IWriter.WriterLastError)))
                {
                    if ((e.ToUpper().Contains(IWriter.NoError)))
                    {
                        iErrorCount += 1;
                        this.txtErrors.ForeColor = Color.Red;
                    }
                }
                this.txtErrors.Text = iErrorCount.ToString() + " Errors found in " + iWriterCount.ToString() + " system writers.";
                if ((e.ToUpper().Contains(IWriter.WriterLastError.ToUpper())))
                {
                    this.rtbVSSList.AppendText(Environment.NewLine);
                }
                Application.DoEvents();
            }
           
        }
        //close any open threads, dont want run away threads!
        private void CloseThreads()
        {
            try
            {
                if (((m_OutputThread != null)))
                {
                    if ((m_OutputThread.IsAlive))
                    {
                        m_OutputThread.Abort();
                    }
                }
                if (((m_ErrorThread != null)))
                {
                    if ((m_ErrorThread.IsAlive))
                    {
                        m_ErrorThread.Abort();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            //begin
            StartVSSDiagnostics();
        }
      
    }
}
