    public class MyForm : Form
    {
        // other form stuff
        
        private System.Diagnostics.Process _encoderProc;
        private void doEncode_Click(object sender, EventArgs e)
        {
            var argument_fmt = "-S --resample 16 --tt {0} --add-id3v2  {1} {2}";
            var dstFile = new TempFile(Path.GetTempFileName());
            var proc = new System.Diagnostics.Process ();
            proc.EnableRaisingEvents = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.FileName = "lame";
            proc.StartInfo.Arguments = String.Format (argument_fmt, 
                                                      title,
                                                      srcFile.Path,
                                                      dstFile.Path);
            proc.Exited += delegate(object sender, EventArgs e) {
                proc.WaitForExit();
                srcFile.Delete();
                
                this.BeginInvoke((MethodInvoker)delegate {
                    // INSERT CODE HERE: your UI-related stuff that you want to do with dstFile
                    this._encoderProc = null;
                });
            };
            proc.Start();
            this._encoderProc = proc;
        }
    }
