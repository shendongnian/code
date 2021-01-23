    public class InheritedClass : BaseClass
    {
        //overrides baseclass constructor but why would you do this given that the     
        //constructor is always going to be called anyway??
        public override InheritedClass()
        {
        }
    }
