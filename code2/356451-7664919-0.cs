    public class MyFoo<TA> : IIFoo<TA>, IFoo<B>
        where TA : A
    {
        public void Handle(TA a) { }
        public void Handle(B b) { }
    }
