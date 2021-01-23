    try
    {
        var engine = Ruby.CreateEngine();
        engine.Runtime.Globals.SetVariable("Holly",new Holly("Test"));
        engine.ExecuteFile(@"..\test.rb");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
