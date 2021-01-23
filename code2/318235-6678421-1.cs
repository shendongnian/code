            private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            //Gets Installed Directory that user selected
            string installDirectory = Path.GetDirectoryName(Context.Parameters["assemblypath"]);
            string[] lines = File.ReadAllLines(installDirectory + "\\NLog.config");
            File.Delete(installDirectory + NLOGFILE);
            StreamWriter sw = File.AppendText(installDirectory + "\\NLog.config");
            foreach (string line in lines)
            {
                if (line.Contains("LOGS"))
                {
                    string logDir = line.Replace("LOGS", installDirectory + "\\LOGS");
                    sw.WriteLine(logDir.Replace('\\', '/'));
                }
                else
                {
                    sw.WriteLine(line);
                }
            }
            sw.Flush();
            sw.Close();
        }
