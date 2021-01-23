    public string calculate(string input)
    {
        try
        {
            ScriptSource source =
                engine.CreateScriptSourceFromString(input,
                    SourceCodeKind.Expression);
            object result = source.Execute(scope);
            return result.ToString();
        }
        catch (Exception ex)
        {
            return "Error";
        }
    }
