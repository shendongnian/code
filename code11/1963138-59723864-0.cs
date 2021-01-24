    public abstract class MasterClass
    {
        public abstract int Stuff();
        // New method that all subclasses will have to implement.
        // You could also have this be virtual with an implementation
        // for Visit(MasterClass) to provider a default behavior.
        public abstract void Accept(IVisitor visitor);
    }
    public class SubClass1 : MasterClass
    {
        public override int Stuff() => 0;
        // We must override this even though its the "same" code in both subclasses
        // because 'this' is a reference to a different type.
        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }
    public class SubClass2 : MasterClass
    {
        public override int Stuff() => 1;
        // We must override this even though its the "same" code in both subclasses
        // because 'this' is a reference to a different type.
        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }
    public interface IVisitor
    {
        // Need an overload for all subclasses.
        void Visit(SubClass1 item);
        void Visit(SubClass2 item);
    }
    public class MasterClassDictionary
    {
        public Dictionary<SubClass1, int> subClass1Dict { get; } = new Dictionary<SubClass1, int>();
        public Dictionary<SubClass2, int> subClass2Dict { get; } = new Dictionary<SubClass2, int>();
        public void Add(MasterClass item)
        {
            int val = item.Stuff();
            var visitor = new Visitor(this, val);
            item.Accept(visitor);
        }
        void AddToDict(SubClass1 item, int val) { subClass1Dict[item] = val; }
        void AddToDict(SubClass2 item, int val) { subClass2Dict[item] = val; }
        // Provides the visitor implementation that holds any state that might
        // be needed and dispatches to the appropriate method.
        private class Visitor : IVisitor
        {
            private MasterClassDictionary _parent;
            private int _value;
            public Visitor(MasterClassDictionary parent, int val)
            {
                _parent = parent;
                _value = val;
            }
            public void Visit(SubClass1 item) => _parent.AddToDict(item, _value);
            public void Visit(SubClass2 item) => _parent.AddToDict(item, _value);
        }
    }
