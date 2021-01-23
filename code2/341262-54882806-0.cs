    using System.Diagnostics;
    ....
	Process[] procName = Process.GetProcessesByName("devenv"); // check if VS is started
	if(procName.Length > 0)
		MessageBox.Show("Wait for debugger attach");
	if (System.Diagnostics.Debugger.IsAttached)
		System.Diagnostics.Debugger.Break();
