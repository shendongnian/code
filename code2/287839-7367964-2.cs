    // Initialize Chakra (requires IE9 to be installed)
    var guid = new System.Guid("{16d51579-a30b-4c8b-a276-0ff4dc41e755}");
    Type t = Type.GetTypeFromCLSID(guid, true);
    // you must have a p/invoke defn for IActiveScript
    var engine = Activator.CreateInstance(t) as IActiveScript;
    var site = new ScriptSite(); // this is a custom class
    engine.SetScriptSite(site);
    var parse32 = engine as IActiveScriptParse32;
    parse32.InitNew();
    // parse a script
    engine.SetScriptState(ScriptState.Connected);
    parse32.ParseScriptText(scriptText, null, null, null, IntPtr.Zero, 0, flags, out result, out exceptionInfo);
    IntPtr comObject;
    engine.GetScriptDispatch(null, out comObject);
    
    // iDispatch is a COM IDispatch  that you can use to invoke script functions. 
    var iDispatch = Marshal.GetObjectForIUnknown(comObject);
    iDispatch.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod, null, iDispatch, arguments);
