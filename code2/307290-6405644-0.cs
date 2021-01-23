    using System.Diagnostics;
    using System;
    
    namespace [whatever]
    {
        class Executor {
            public event EventHandler Completed;
            public event DataReceivedEventHandler DataReceived;
            public event DataReceivedEventHandler ErrorReceived;
    
            public void callExecutable(string executable, string args, string workingDir){
                string commandLine = executable;
                ProcessStartInfo psi = new ProcessStartInfo(commandLine);
                psi.UseShellExecute = false;
                psi.LoadUserProfile = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.WindowStyle = ProcessWindowStyle.Minimized;
                psi.CreateNoWindow = true;
                psi.Arguments = args;
                psi.WorkingDirectory = System.IO.Path.GetDirectoryName(executable);
                psi.WorkingDirectory = workingDir;
                Process p = new Process();
                p.StartInfo = psi;
                try{
                    p.EnableRaisingEvents = true;
                    p.Start();
                    if (DataReceived != null) p.OutputDataReceived += DataReceived;
                    if (ErrorReceived != null) p.ErrorDataReceived += ErrorReceived;
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                    p.Exited += new EventHandler(p_Exited);
                }
                catch (Exception ex){
                    //log.Error(ex.Message);
                }
            }
    
            void p_Exited(object sender, EventArgs e) {
                (sender as Process).Close();
                (sender as Process).Dispose();
                if (Completed != null) {
                    Completed(this, e);
                }
            }
        }
    }
    /*
        //In another class
            private void CallProgram() {
                Executor exec = new Executor();
                exec.Completed += new EventHandler(exec_Completed);
                exec.DataReceived += new System.Diagnostics.DataReceivedEventHandler(exec_DataReceived);
                exec.ErrorReceived += new System.Diagnostics.DataReceivedEventHandler(exec_ErrorReceived);
                exec.callExecutable([Program Name],
                    [Arguments],
                    [Working Dir]);
            }
    
            void exec_Completed(object sender, EventArgs e) {
                MessageBox.Show("Finshed");
            }
      
            void exec_DataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e) {
                if (e.Data != null) {
                    AddText(e.Data.ToString());
                }
            }
     
            void exec_ErrorReceived(object sender, System.Diagnostics.DataReceivedEventArgs e) {
                if (e.Data != null) {
                    AddText(e.Data.ToString());
                }
            }
      
            // this handles the cross-thread updating of a winforms control
            private void AddText(string textToAdd) {
                if (textBox1.InvokeRequired) {
                    BeginInvoke((MethodInvoker)delegate() { AddText(textToAdd); });
                }
                else {
                    textBox1.AppendText(textToAdd);
                    textBox1.AppendText("\r\n");
                    textBox1.Refresh();
                }
            }
      
    */
