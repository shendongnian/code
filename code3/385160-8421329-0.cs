        foreach (Process theProcess in Process.GetProcesses())
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendLine(theProcess.Modules[0].FileName);
            }
            catch { }
            Console.WriteLine("Process: {0}  ID:  {1}", sb, theProcess.Id);
        }
