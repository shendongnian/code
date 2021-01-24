       		private IntPtr hJob = IntPtr.Zero;
        
        	bool bRet = false;
            hJob  = CreateJobObject(IntPtr.Zero, "Test Job Object");
            JOBOBJECT_EXTENDED_LIMIT_INFORMATION jbeli = new JOBOBJECT_EXTENDED_LIMIT_INFORMATION();
            jbeli.BasicLimitInformation.LimitFlags |= (JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE | JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK | JOB_OBJECT_LIMIT_BREAKAWAY_OK);
            int nLength = Marshal.SizeOf(typeof(JOBOBJECT_EXTENDED_LIMIT_INFORMATION));
            IntPtr pJobInfo = Marshal.AllocHGlobal(nLength);
            Marshal.StructureToPtr(jbeli, pJobInfo, false);           
            SetInformationJobObject(hJob, JOBOBJECTINFOCLASS.JobObjectExtendedLimitInformation, pJobInfo, (uint)nLength);
            Marshal.FreeHGlobal(pJobInfo);
            int nNbProcesses = 5;
            for (int i = 0; i < nNbProcesses; i++)
            {
                using (Process exeProcess = new Process())
                {
                    exeProcess.StartInfo.FileName = "notepad";
                    exeProcess.Start();
                    exeProcess.WaitForInputIdle();
                    IntPtr hProcess = exeProcess.Handle;
                    bRet = AssignProcessToJobObject(hJob, hProcess);
                }
            }
            JOBOBJECT_BASIC_PROCESS_ID_LIST jobpil = new JOBOBJECT_BASIC_PROCESS_ID_LIST();
            jobpil.NumberOfAssignedProcesses = nNbProcesses;
            int nSize = Marshal.SizeOf<JOBOBJECT_BASIC_PROCESS_ID_LIST>() + (nNbProcesses - 1) * Marshal.SizeOf<IntPtr>();
            IntPtr pJobpil = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(jobpil, pJobpil, false);
            int nReturnLength = 0;
            bRet = QueryInformationJobObject(hJob, JOBOBJECTINFOCLASS.JobObjectBasicProcessIdList,  pJobpil, nSize, out nReturnLength);
            if (bRet)
            {
                var processidlist = new JOBOBJECT_BASIC_PROCESS_ID_LIST(pJobpil);
                foreach (var pid in processidlist.ProcessIdList)
                {
                    Console.WriteLine("PID: {0}", pid.ToString());
                }
            }
            else
            {
                int nErr = Marshal.GetLastWin32Error();
                Win32Exception win32Exception = new Win32Exception(nErr);
                this.Activate();
                MessageBox.Show("Error: " + win32Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Marshal.FreeHGlobal(pJobpil);
            
            
        // CloseHandle can be added in Form1_FormClosed :
            
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseHandle(hJob);
        }
