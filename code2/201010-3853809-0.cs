    var commandList = new List<Command>() { new MyABCCommand() };
    foreach (Command c in commandList)
    {
        if (c.Accept(mystring))
        {
            c.Execute(mystring);
            break;
        }
    }
    class MyABCCommand : Command
    {
        override bool Accept(string mystring)
        {
            return mystring.StartsWith("abc");
        }
    }    
