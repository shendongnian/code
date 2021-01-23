    IEnumerable result = null;
    try 
    {
        var scriptOptions = ScriptOptions.Default.WithReferences(typeof(System.Linq.Enumerable).Assembly).WithImports("System.Linq");
        result = await CSharpScript.EvaluateAsync<IEnumerable>(
                 TextBox.Text,
                 scriptOptions,
                 globals: global);
    } catch (CompilationErrorException ex) {
    //
    }
