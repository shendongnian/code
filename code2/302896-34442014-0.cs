    public class Visitable1
    {
        public void Accept(dynamic visitor)
        {
            visitor.Visit(this);
        }
    }
    public class DynamicVisitor
    {
        public void Visit(Visitable1 token)
        {
            // Call token methods/properties
        }
    }
