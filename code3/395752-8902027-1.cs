    var engine = Ruby.CreateRuntime().GetEngine("rb");
    engine.Execute("/*your script goes here*/");
    
    dynamic rubyScope = engine.Runtime.Globals;
    dynamic myImplInstance = rubyScope.MyInterfaceImpl.@new();
    
    var input = //.. your parameter
    var myResult = myImplInstance.DoStuff(input );
