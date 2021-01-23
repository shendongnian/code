    Public interface ImmutableItem {
        decimal Amount {get;}
        string Currency {get;}
    }
    Public interface MutableItem: ImmutableItem {
        decimal Amount {set;}
        string Currency {set;}
    }
    class Concrete : ImmutableItem  {
        //Only getters
    }
    
    
    class Concrete : MutableItem  {
       //Both getters & setters
    }
