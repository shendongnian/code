    abstract class PlayerBase
    {
        public abstract TheType StateMachine { get; set; }  // declare here
        // if PlayerBase is not abstract, you can declare the property as: 
        // public virtual TheType StateMachine { get; set; }
    }
    
    class FieldPlayer : PlayerBase 
    {
        public override TheType StateMachine { get; set; } // implement here
    }
