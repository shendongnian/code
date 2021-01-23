    void Main()
    {
    	var engine = Ruby.CreateEngine();
    	var buffer = new MemoryStream();
    	engine.Runtime.IO.SetOutput(buffer, new StreamWriter(buffer));
    	engine.ExecuteFile(@"c:\temp\gen.rb");
    	ObjectHandle handle = engine.ExecuteAndWrap("Generator::CmdLine.new('the output')");
        var scope = engine.CreateScope();
    	scope.SetVariable("myvar", handle);
    	engine.Execute("myvar.run", scope);
        engine.Operations.InvokeMember(handle.Unwrap(), "run", "InvokeMember");
    	buffer.Position = 0;
    	Console.WriteLine(new StreamReader(buffer).ReadToEnd());
    }
