    using System;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    public class MyIronPythonHost
    {
        ScriptEngine scriptEngine;
        ScriptScope scriptScope;
        
        public void Initialize(MyApplication myApplication)
        {
            scriptEngine = Python.CreateEngine();
            scriptScope = scriptEngine.CreateScope();
            scriptScope.SetVariable("app", myApplication);
        }
        
        public void RunPythonCode(string code)
        {
            ScriptSource scriptSource = scriptEngine.CreateScriptSourceFromString(code);
            scriptSource.Execute(scriptScope);
        }
    }
