	var extraModulesPath = "somepath";
	var state = InitialSessionState.CreateDefault();
	using (var rs = RunspaceFactory.CreateRunspace(state))
	{
		rs.Open();
		using (var ps = PowerShell.Create())
		{
			ps.Runspace = rs;
			var psModulePath = rs.SessionStateProxy.GetVariable("env:PSModulePath");
			rs.SessionStateProxy.SetVariable("env:PSModulePath", $"{psModulePath};{extraModulesPath}");
			ps.AddScript("Import-Module('ACMESharp')");
			ps.Invoke();
			var output = ps.HadErrors
				? ps.Streams.Error.ToString()
				: ps.Streams.Information.ToString();
		}
	}
