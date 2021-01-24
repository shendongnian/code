// use case - executing scripts
public enum ScriptType
{
    CSharp = 0,
    Python = 1,
}
Model = new ScriptEditorModel(new ScriptType[] { ScriptType.Python, ScriptType.CSharp });
Model.GetExecutionContextFor(ScriptType.Python).ExecuteScript("python_script.py")
Model.GetExecutionContextFor(ScriptType.CSharp ).ExecuteScript("csharp_script.cs")
...
// ScriptEditorModel - could be
public class ScriptEditorModel
{
    public ScriptType[] SupportedScriptTypes { get; set; }
    public ScriptEditorModel(ScriptType[] supportedScripts)
    {
        
        SupportedScriptTypes = supportedScripts;
        foreach (ScriptType supportedScript in SupportedScriptTypes)
        {
            AddSupportFor(supportedScript);
        }
    }
    public void AddSupportFor(ScriptType scriptType)
    {
        switch (scriptType)
        {
            case ScriptType.CSharp:
                var cSharpExecutionContext = new CSharpExecutionContext()
                {
                    Options = ScriptOptions.Default
                };
                ExecutionContexts[scriptType] = cSharpExecutionContext;
                break;
            case ScriptType.Python:
                var pythonExecutionContext = new ScriptExecutionContext()
                {
                    Engine = Python.CreateEngine(),
                    Options = ScriptOptions.Default
                };
                // add the standard library to engine
                ICollection<string> searchPaths = pythonExecutionContext.Engine.GetSearchPaths();
                searchPaths.Add("..\\..\\Lib");
                pythonExecutionContext.Engine.SetSearchPaths(searchPaths);
                pythonExecutionContext.Scope = pythonExecutionContext.Engine.CreateScope();
                ExecutionContexts[scriptType] = pythonExecutionContext;
                break;
            default:
                return;
        }
        ExecutionContexts[scriptType].SetIOOutput(_memoryStream, StdOutputWriter);
        ExecutionContexts[scriptType].SetIOErrorOutput(_memoryStream, StdErrorWriter);
    }
    public IScriptExecutionContext GetExecutionContextFor(ScriptType scriptType)
    {
        try
        {
            return ExecutionContexts[scriptType];
        }
        catch (KeyNotFoundException e)
        {
            return null;
        }
    }
}
// and the Script Execution Contexts implement the interface below
public interface IScriptExecutionContext
{
    ScriptOptions Options { get; set; }
    Task<Exception> ExecuteScript(ScriptDefinition scriptIn, CancellationToken ctIn);
    void SetIOOutput(Stream stream, TextWriter writer);
    void SetIOErrorOutput(Stream stream, TextWriter writer);
    Dictionary<string, object> Globals { get; set; }
    void SetGlobal(string accessName, object global);
}
// Example
public abstract class BaseScriptExecutionContext : IScriptExecutionContext
    {
        public Dictionary<string, object> Globals { get; set; } = new Dictionary<string, object>();
        public ScriptOptions Options { get; set; }
        public abstract Task<Exception> ExecuteScript(ScriptDefinition scriptIn, CancellationToken ctIn);
        public abstract void SetIOErrorOutput(Stream stream, TextWriter writer);
        public abstract void SetIOOutput(Stream stream, TextWriter writer);
        public virtual void SetGlobal(string accessName, object global)
        {
            Globals[accessName] = global;
        }
    }
    public class ScriptExecutionContext : BaseScriptExecutionContext
    {
        public CompiledCode CompiledCode;
        public ScriptSource SourceCode;
        public ScriptEngine Engine;
        public ScriptScope Scope;
        public override Task<Exception> ExecuteScript(ScriptDefinition scriptIn, CancellationToken ctIn)
        {
            return Task.Run(() =>
            {
                try
                {
                    SourceCode = Engine.CreateScriptSourceFromFile(scriptIn.FilePath);
                    CompiledCode = SourceCode.Compile();
                    CompiledCode.Execute(Scope);
                    return null;
                }
                catch (Exception e)
                {
                    return e;
                }
            }, ctIn);
        }
        public override void SetGlobal(string accessName, object global)
        {
            base.SetGlobal(accessName, global);
            Scope.SetVariable(accessName, global);
        }
        public override void SetIOErrorOutput(Stream stream, TextWriter writer)
        {
            Engine.Runtime.IO.SetOutput(stream, writer);
            Engine.Runtime.IO.SetErrorOutput(stream, writer);
        }
        public override void SetIOOutput(Stream stream, TextWriter writer)
        {
            Engine.Runtime.IO.SetOutput(stream, writer);
            Engine.Runtime.IO.SetErrorOutput(stream, writer);
        }
    }
    public class CSharpExecutionContext : BaseScriptExecutionContext
    {
        private Stream _errorStream;
        private Stream _outputStream;
        public override async Task<Exception> ExecuteScript(ScriptDefinition scriptIn, CancellationToken ctIn)
        {
            //var process = new Process
            //{
            //}
            return await Task.Run(async () =>
            {
                try
                {
                    //var script = CSharpScript.Create(
                    //        code: File.ReadAllText(scriptIn.FilePath),
                    //        Options,
                    //        Globals.GetType()
                    //    );
                    //Compilation compilation = script.GetCompilation();
                    //compilation.
                    var result = await CSharpScript.EvaluateAsync(
                            code: File.ReadAllText(scriptIn.FilePath),
                            Options,
                            Globals,
                            Globals.GetType(),
                            ctIn
                        );
                    return null;
                }
                catch (Exception e)
                {
                    return e;
                }
            }, ctIn);
        }
        public override void SetIOErrorOutput(Stream stream, TextWriter writer)
        {
            _errorStream = stream;
        }
        public override void SetIOOutput(Stream stream, TextWriter writer)
        {
            _outputStream = stream;
        }
    }
