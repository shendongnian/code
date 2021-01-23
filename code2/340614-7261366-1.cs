    public class EnhancedThing
    {
        private readonly OriginalThing originalThing;
            
        public static implicit operator OriginalThing(EnhancedThing enhancedThing)
        {
            return enhancedThing.originalThing;
        }
    
        public static implicit operator EnhancedThing(OriginalThing originalThing)
        {
            return new EnhancedThing(originalThing);
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
            // extra processing ...
            return value;
        }
    }
    // no need to cast
    EnhancedThing thing = new OriginalThing();
    var result = thing.NewMethod();
    // again no need to cast, treat as original when passing around
    OriginalThing original = thing;
