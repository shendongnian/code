    ScriptEngine engine = Python.CreateEngine();
    ScriptRuntime runtime = engine.Runtime;
    ScriptScope scope = runtime.CreateScope();
    // In an actual application you might even be
    // parsing the script from user input.
    ScriptSource source = engine.CreateScriptSourceFromFile(...); 
    Player p = new Player();
    scope.SetVariable("player", p);
    source.Execute(scope);
