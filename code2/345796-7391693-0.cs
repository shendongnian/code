     Process process = new System.Diagnostics.Process();
     process.EnableRaisingEvents = false;
     process.StartInfo.CreateNoWindow = true;
     process.StartInfo.FileName = filePath;
     string arguments = fileArguments;
     process.StartInfo.Arguments = fileArguments;
     process.Start();
     process.WaitForExit();
