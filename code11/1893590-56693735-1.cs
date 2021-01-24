    private void button1_Click(object sender, EventArgs e)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "c:\\ffmpeg\\bin\\ffmpeg.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = "-i shatner.mp4 shatner.avi";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;       
    
    
                using (Process exeProcess = Process.Start(startInfo))
                {
                    string error = exeProcess.StandardError.ReadToEnd();
                    string output = exeProcess.StandardError.ReadToEnd();
                    exeProcess.WaitForExit();
                   
                    MessageBox.Show("ERROR:" + error);
                    MessageBox.Show("OUTPUT:" + error);
                }
            }
