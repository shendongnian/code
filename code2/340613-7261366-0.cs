     public class EnhancedThing
     {
              private readonly OriginalThing originalThing;
        
             public static implicit operator OriginalThing(EnhancedThing enhancedThing)
             {
                  return enhancedThing.originalThing;
             }
              public static implicit EnhancedThing(OriginalThing originalThing)
              {
                   Return new EnhancedThing(originalThing);
              }
              private EnhancedThing(OriginalThing originalThing)
              {
                     this.originalThing = originalThing;
              }
        
              public string OriginalMethod()
              {
                    return originalThing.OriginalMethod();
              }
              public string NewMethod()
              {
                    var value = originalThing.OriginalMethod();
                    // extra processing
                    return value;
              }
    }
 
    // no need to cast
    EnhancedThing thing = OriginalFactory.Create();
     var result = thing.NewMethod();
