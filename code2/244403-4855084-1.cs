    public class DerivedClass : BaseClass
    {
        public override BaseObject[] Objects {get; set;}
    
        public override void DoStuff()
        {
            // Do stuff unique to the derived.
    
            base.DoStuff();
        }
    }
