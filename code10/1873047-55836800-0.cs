    public abstract class BaseClass
    {
        public virtual string MutualString { get; set; }
    }
    public class Derived1 :BaseClass
    {
        public virtual Object1 Kisi { get; set; }
        public override string MutualString
        {
            get { return Kisi.TamAd; } //*TamAd is string.
            set { value = Kisi.TamAd; }
        }
    }
    public class Derived2 : BaseClass
    {
        public virtual Object2 Firma{ get; set; }
        public override string MutualString
        {
            get { return Firma.TamAd; }
            set { value = Firma.TamAd; }
        }
    }
