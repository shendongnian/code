        private void RunSDLProgram()
        {
            FileInfo spectrumFileInfo = new FileInfo("pathToFile.exe");
            ProcessStartInfo info = new ProcessStartInfo(spectrumFileInfo.FullName);
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.UseShellExecute = false;
            info.WorkingDirectory = spectrumFileInfo.DirectoryName;
            pVizualizer = new Process();
            pVizualizer.StartInfo = info;
            pVizualizer.EnableRaisingEvents = true;
            pVizualizer.Exited += new EventHandler(myProcess_Exited);
            pVizualizer.Start();
        }
        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            Console.WriteLine(
                $"Exit time    : {pVizualizer.ExitTime}\n" +
                $"Exit code    : {pVizualizer.ExitCode}\n" +
                $"output    : {pVizualizer.StandardOutput}\n" +
                $"err    : {pVizualizer.StandardError}\n" 
                );
        }
