    var r = (HttpRequest)Activator.CreateInstance(
				typeof(HttpRequest),
				BindingFlags.Instance | BindingFlags.NonPublic,
				null,
				new object[]
					{
						workerRequest,
						new HttpContext(workerRequest)
					},
				null);
    var runtimeField = typeof (HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
    if (runtimeField == null)
    {
        return;
    }
    
    var runtime = (HttpRuntime) runtimeField.GetValue(null);
    if (runtime == null)
    {
        return;
    }
    
    var codeGenDirField = typeof(HttpRuntime).GetField("_codegenDir", BindingFlags.Instance | BindingFlags.NonPublic);
    if (codeGenDirField == null)
    {
        return;
    }
    
    codeGenDirField.SetValue(runtime, @"C:\MultipartTemp");
