		/// <summary>
		/// Kill a process, and all of its children, grandchildren, etc.
		/// </summary>
		/// <param name="pid">Process ID.</param>
		private static void KillProcessAndChildren(int pid)
		{
            // Cannot close 'system idle process'.
            if (pid == 0)
            {
                return;
            }
			ManagementObjectSearcher searcher = new ManagementObjectSearcher
              ("Select * From Win32_Process Where ParentProcessID=" + pid);
			ManagementObjectCollection moc = searcher.Get();
			foreach (ManagementObject mo in moc)
			{
				KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
			}
			try
			{
				Process proc = Process.GetProcessById(pid);
				proc.Kill();
			}
			catch (ArgumentException)
			{
				// Process already exited.
			}
		}
