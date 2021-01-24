    public abstract class Parent
    {
        public int ParentIntField;
        virtual public void Manipulate()
        {            
            //maybe do some job with other.ParentIntField
        }
    }
    public class Child : Parent
    {
        public int ChildIntField;
        public override void Manipulate()
        {
            int x = ChildIntField; //do some job with ChildIntField            
            base.Manipulate();
        }
    }
