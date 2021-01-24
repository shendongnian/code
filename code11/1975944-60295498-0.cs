    public abstract class BaseClass
    {
        public const string BananaSetting = "BananaSetting";
        public abstract void BaseAbstractMethod();
        public void BaseMethod()
        {
        }
    }
    public class DerivedClass : BaseClass
    {
        public const string DerivedBananaSetting = "DerivedBananaSetting";
        public override void BaseAbstractMethod()
        {
        }
    }
