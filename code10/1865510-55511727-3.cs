    public interface IClass
    {
         void Visit(IClassVisitor visitor);
    }
    public interface IClassVisitor
    {
        void Accept(Class1 c1);
        void Accept(Class2 c2);
    }
    public class Class1 : IClass
    {
        public void Visit(IClassVisitor visitor) => visitor.Accept(this);
    }
    public class Class2 : IClass
    {
        public void Visit(IClassVisitor visitor) => visitor.Accept(this);
    }
