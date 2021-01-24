    public abstract class BaseClass
    {
        protected BaseClass(BaseClass baseObj)
        {
            Abc = baseObj.Abc;
            Pqr = baseObj.Pqr;
            Xyz = baseObj.Xyz;
        }
    
        [...]
    }
