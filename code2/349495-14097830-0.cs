    private void comp_Click(object sender, EventArgs e)
        {
            string text = "javac " + label1.Text + file + "@pause" + "@stop";
            text = text.Replace("@", System.Environment.NewLine);
            File.WriteAllText(label1.Text + "Compile.bat", text);
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = label1.Text + "Compile.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch
            {
                
            }
        }
        private void runp_Click(object sender, EventArgs e)
        {
            string news = file.Remove(file.Length - 5);
            string text = "java " + news + "@pause";
            text = text.Replace("@", System.Environment.NewLine);
            File.WriteAllText(label1.Text + "Run.bat", text);
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = label1.Text + "Run.bat";
                proc.StartInfo.WorkingDirectory = label1.Text.Remove(label1.Text.Length - 1);
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
            catch
            {
            }
        }
