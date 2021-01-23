	System.Text.StringBuilder sb = new System.Text.StringBuilder();
	var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
	sb.AppendLine("Process information");
	sb.AppendLine("-------------------");
	sb.AppendLine("CPU time");
	sb.AppendLine(string.Format("\tTotal       {0}",
		currentProcess.TotalProcessorTime));
	sb.AppendLine(string.Format("\tUser        {0}",
		currentProcess.UserProcessorTime));
	sb.AppendLine(string.Format("\tPrivileged  {0}",
		currentProcess.PrivilegedProcessorTime));
	sb.AppendLine("Memory usage");
	sb.AppendLine(string.Format("\tCurrent     {0:N0} B", currentProcess.WorkingSet64));
	sb.AppendLine(string.Format("\tPeak        {0:N0} B", currentProcess.PeakWorkingSet64));
	sb.AppendLine(string.Format("Active threads      {0:N0}", currentProcess.Threads.Count));
