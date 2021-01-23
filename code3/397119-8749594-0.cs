    // work with any version
    Type wordType = Type.GetTypeFromProgId( "Word.Application" );
    
    dynamic wordApp = Activator.CreateInstance( wordType );
    // late binding + dynamics - always works
    wordApp.Visible = true;
