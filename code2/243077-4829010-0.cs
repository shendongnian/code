    /// <summary>
    /// Set up an IronPython environment - for interactive shell or for canned scripts
    /// </summary>
    public void SetupEnvironment(ScriptEngine engine, ScriptScope scriptScope)
    {
        // add variables from Revit
        scriptScope.SetVariable("__revit__", _commandData.Application);
        scriptScope.SetVariable("__commandData__", _commandData);
        scriptScope.SetVariable("__message__", _message);
        scriptScope.SetVariable("__elements__", _elements);
        scriptScope.SetVariable("__result__", (int)Result.Succeeded);           
        // add preconfigures variables
        scriptScope.SetVariable("__vars__", RevitPythonShellApplication.GetVariables());
        // add the current scope as module '__main__'
        var languageContext = Microsoft.Scripting.Hosting.Providers.HostingHelpers.GetLanguageContext(engine);
        var pythonContext = (IronPython.Runtime.PythonContext)languageContext;
        var module = pythonContext.CreateModule(null, GetScope(scriptScope), null, IronPython.Runtime.ModuleOptions.None);            
        pythonContext.PublishModule("__main__", module);
        // add the search paths
        AddSearchPaths(engine);
    }
    /// <summary>
    /// Be nasty and reach into the ScriptScope to get at its private '_scope' member,
    /// since the accessor 'ScriptScope.Scope' was defined 'internal'.
    /// </summary>
    private Microsoft.Scripting.Runtime.Scope GetScope(ScriptScope scriptScope)
    {
        var field = scriptScope.GetType().GetField(
            "_scope", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (Microsoft.Scripting.Runtime.Scope) field.GetValue(scriptScope);
    }
