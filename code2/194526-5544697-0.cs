    public interface IShallowClone<T> { T ShallowClone(); }
    public interface IDeepClone<T> { T DeepClone(); }
    public interface IA : IShallowClone<IA>, IDeepClone<IA> { double a { get; } IA ia { get; } }
    public interface IB : IA, IShallowClone<IB>, IDeepClone<IB> { double b { get; } IB ib { get; } }
    public class A : IA
    {
        public double a { get; private set; } 
        public IA ia { get; private set; }
        public A(IA that) { this.a = that.a; this.ia = (ia as IDeepClone<IA>).DeepClone(); } 
        public IA DeepClone() { return new A(this); }
        public IA ShallowClone() { return this.MemberwiseClone() as IA; }
    }
    public class B : A, IB 
    { public double b { get; private set; } 
        public IB ib { get; private set; }
        public B(IB that) : base(that) { this.b = that.b; this.ib = (ib as IDeepClone<IB>).DeepClone(); } 
        public new IB DeepClone() { return new B(this); }
        public new IB ShallowClone() { return this.MemberwiseClone() as IB; }
    }
