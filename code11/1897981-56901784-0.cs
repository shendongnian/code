         System.Diagnostics.Process process = new System.Diagnostics.Process();
              process.StartInfo = new System.Diagnostics.ProcessStartInfo()
              {
                  UseShellExecute = false,
                  CreateNoWindow = false,
                  WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                  FileName = "cmd.exe",
                  Arguments = @"/C python detect_slow.py --images img", 
                  RedirectStandardError = true,
                  RedirectStandardOutput = true
              };
              process.Start();
              string output = process.StandardOutput.ReadToEnd();
              process.WaitForExit();
              richTextBox1.Text += output;
