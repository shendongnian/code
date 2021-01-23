    var engine = Ruby.CreateEngine();
    var scope = engine.ExecuteFile(@"C:\codebase\Test\Test2\Test2\person2.rb");
    
    dynamic globalConstants = engine.Runtime.Globals;
    dynamic person = globalConstants.Person.@new("shay");
    person.sayHi();
