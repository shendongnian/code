    public class BaseC : Form
    {
        public virtual bool ReversePlace => false;
        //etc....
    }
    public class DerivedC1 : BaseC
    {
        public override bool ReversePlace => true;
    }
    public class DerivedC2 : BaseC
    {
        public override bool ReversePlace => false;
    }
