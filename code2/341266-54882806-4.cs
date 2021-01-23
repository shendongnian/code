    using System.Diagnostics;
    ....
	Process[] procName = Process.GetProcessesByName("devenv"); // check if VS currently running
    // If Visual Studio is running halt the application by showing a MessageBox and give opportunity to attach the debugger
	if(procName.Length > 0)
		MessageBox.Show("Wait for debugger attach");
    // Force a breakpoint when the debugger became attached
	if (System.Diagnostics.Debugger.IsAttached)
		System.Diagnostics.Debugger.Break(); // force a breakpoint
