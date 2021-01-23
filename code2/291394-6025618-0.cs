    public string evaluate(string x, string code)
    {
        scope.SetVariable("x", x);
        scope.SetVariable("button", this.button);
    
        try
        {
            ScriptSource source = engine.CreateScriptSourceFromString(code,
                SourceCodeKind.Statements);
    
            source.Execute(scope);
        }
        catch (Exception ex)
        {
            return "Error executing code: " + ex.ToString();
        }
    
        if (!scope.VariableExists("x"))
        {
            return "x was deleted";
        }
        string result = scope.GetVariable<object>("x").ToString();
        return result;
    }
