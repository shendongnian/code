    int numberOfCopies = 2;
    Process process = new System.Diagnostics.Process();
    for (int i = 1; i <= numberOfCopies; i++)
        {
                process.EnableRaisingEvents = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = foxitReaderInstalledPath;
                string arguments = String.Format(@"-t ""{0}"" ""{1}""", this.Path, printerName);
                process.StartInfo.Arguments = arguments;
                process.Start();
        }
