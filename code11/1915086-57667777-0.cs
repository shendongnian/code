        public abstract class Parent
    {
        public int ParentIntField;
        public void ParentMethod(Parent other)
        {
            if (other is Child)
            {
                Child childObject = (Child)other; // We are casting the object here.
                int x = childObject.ChildIntField;
                //do some job with other.ChildIntField
            }
            //maybe do some job with other.ParentIntField
        }
    }
    public class Child : Parent
    {
        public int ChildIntField;
    }
