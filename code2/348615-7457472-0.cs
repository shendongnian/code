    abstract class PlayerBase
    {
        public abstract TheType StateMachine { get; set; }  // declare here
    }
    
    class FieldPlayer : PlayerBase 
    {
        public override TheType StateMachine { get; set; } // implement here
    }
