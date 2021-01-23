    internal interface IA
    {
        void X(); //OK. It will work
    }
    internal class CA : IA
    {
        **internal** void X() // internal modifier is NOT allowed on any Interface members. It doesn't compile. If it works in your project it's because either you DON'T have the void X() method in the Interface or your are inheriting from a wrong interface maybe accidentally 
        {
            ...
        }
    }
