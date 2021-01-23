    public class Selection
    {
        public abstract object Select();
    }
    public class SelectionA : Selection
    {
        public override object Select()
        {
            return new A();
        }
    }
    public class SelectionB : Selection
    {
        public override object Select()
        {
            return new B();
        }
    }
    // ...
    public Object getObject(Selection selection)
    {
        return selection.Select();
    }
