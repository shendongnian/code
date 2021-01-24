    abstract class C1
    {
        public abstract void M1();
    }
    
    class Cx : C1
    {
        public override void M1()
        {
            // ...
        }
    }
    
    class CxWithCommonBehavior : C1
    {
        C1 realObject;
    
        public CxWithCommonBehavior(C1 realObject)
        {
            this.realObject = realObject;
        }
    
        public override void M1()
        {
            // common behavior
            realObject.M1();
        }
    }
