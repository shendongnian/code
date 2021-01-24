    using Omu.ValueInjecter;
    public abstract class BaseClass
    {
        protected BaseClass(BaseClass baseObj)
        {
            this.InjectFrom(baseObj);
        }
        public string Abc { get; set; }
        public int Pqr { get; set; }
        public object Xyz { get; set; }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass(BaseClass baseObj, int new1, object new2) : base(baseObj)
        {
            New1 = new1;
            New2 = new2;
        }
        public int New1 { get; set; }
        public object New2 { get; set; }
    }
