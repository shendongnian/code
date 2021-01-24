     private void button1_Click(object sender, EventArgs e)
            {
                Process proc = null;
                try
                {
                    string batDir = string.Format(@"D:\"); //path of bat
                    proc = new Process();
                    proc.StartInfo.WorkingDirectory = batDir;
                    proc.StartInfo.FileName = "testbat.bat";
                    proc.StartInfo.CreateNoWindow = false;
                    proc.Start();
                    proc.WaitForExit();
                    MessageBox.Show("Bat file executed !!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace.ToString());
                }
            }
