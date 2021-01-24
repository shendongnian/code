    // have a base class (or an interface), that Milk, Coffee, etc derive from (or implement)
    // the main thing is the abstraction part.
    public abstract class Ingredient 
    {
       // define anything common in here, and/or something all subclasses MUST implement
    }
    
    // let Milk, Coffe, etc extend that class
    public class Milk : Ingredient
    {
         // special fields, properties, methods for Milk
    }
    
    
