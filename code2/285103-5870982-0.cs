    public abstract class RealObject
    {
        public abstract void Accept(RealObjectVisitor visitor);
    }
    public class Man : RealObject
    {
        public override void Accept(RealObjectVisitor visitor)
        {
            visitor.VisitMan(this);
        }
    }
    public class Woman : RealObject
    {
        public override void Accept(RealObjectVisitor visitor)
        {
            visitor.VisitWoman(this);
        }
    }
    public abstract class RealObjectVistor
    {
        public abstract void VisitMan(Man man);
        public abstract void VisitWoman(Woman woman);        
    }
    public class VirtualObjectFactory
    {
        public VirtualObject Create(RealObject realObject)
        {
            Visitor visitor = new Visitor();
            realObject.Accept(visitor);
            return visitor.VirtualObject;
        }  
        private class Visitor : RealObjectVistor
        {  
            public override void VisitMan(Man man)
            {
                VirtualObject = new ManVirtualObject(man);
            }
            public override void VisitWoman(Woman woman)
            {
                VirtualObject = new WomanVirtualObject(woman);
            }
            public VirtualObject VirtualObject { get; private set; }
        }   
    }
