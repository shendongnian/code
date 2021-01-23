    private void button1_Click(object sender, EventArgs e)
            {
                string arg1 = "1";
                Process p1 = new Process();
                p1.StartInfo.CreateNoWindow = true;
                p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p1.StartInfo.FileName = @"yourExecutable";
                p1.StartInfo.Arguments = arg1;
                p1.StartInfo.UseShellExecute = false;
                p1.StartInfo.RedirectStandardOutput = true;
                p1.StartInfo.RedirectStandardInput = true;
                p1.StartInfo.RedirectStandardError = true;
                p1.Start();
                //while (!p1.HasExited)
                //{
    
                // }
    
                MessageBox.Show(p1.StandardOutput.ReadToEnd());
                
                button2.Focus();  // set button 2 to have a height of 0 so it is not visible
                // or place it somewhere where it cannot be seen
                
    
    
            }
