    class EnhancedThing : OriginalThing
    {
      public string Name { get; private set; }
      static EnhancedThing GetNewThing(string name)
      {
         EnhanedThing thing = new EnhancedThing();
         thing.Name = name;
         return thing;
      }
    }
    
    // ...
    
    OriginalThing foo = EnhancedThing.GetNewThing( "someName" );
