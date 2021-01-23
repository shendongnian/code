    class EnhancedThing : OriginalThing
    {
      string name;
      static EnhancedThing GetNewThing(string name)
      {
         EnhancedThing ething = new OriginalThing();
         ething.Name = name;
      }
    }
    
    // ...
    
    OriginalThing foo = EnhancedThing.GetNewThing( "someName" );
