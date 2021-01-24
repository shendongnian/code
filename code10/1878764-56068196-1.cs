    public async void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Input_job_file) && !String.IsNullOrEmpty(Log_file ))
            {
                textBox3.Text = "Executing code...\r\n";
                string outtext;
                string batpath = string.Format(Settings.Default.path_to_gamess + "\\rungms.bat");
                string arguments = string.Format("{0} {1} {2} 0 {3}", Input_job_file, Settings.Default.version, Ncpus, Log_file);
                //Here we need to copy the input file to the gamess directory in order to avoid errors
                File.Copy(Input_job_file, Settings.Default.path_to_gamess + "\\" + FileNameWithoutExtension + ".inp");
                Process gamessjob = new Process();
                gamessjob.StartInfo.ErrorDialog = true;
                gamessjob.StartInfo.UseShellExecute = false;
                gamessjob.StartInfo.CreateNoWindow = true;
                gamessjob.StartInfo.RedirectStandardOutput = true;
                gamessjob.StartInfo.RedirectStandardError = true;
                gamessjob.EnableRaisingEvents = true;
                gamessjob.StartInfo.WorkingDirectory = Settings.Default.path_to_gamess;
                gamessjob.StartInfo.FileName = batpath;
                gamessjob.StartInfo.Arguments = arguments; //input_file, version, number_of_processors, "0", output_name]
                gamessjob.Start();
                //STDOUT redirection to our textbox in readonly mode
                while((outtext = await gamessjob.StandardOutput.ReadLineAsync()) != null)
                {
                    textBox3.Text += outtext + "\r\n";
                }
                textBox3.Text += "\r\nProcess executed!";
                //here we clean up some stuff after GAMESS code ends
                File.Delete(Settings.Default.path_to_gamess + "\\" + FileNameWithoutExtension + ".inp");
                MessageBox.Show("Code executed!\nCheck output for errors or messages.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Input file and/or output location is invalid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
