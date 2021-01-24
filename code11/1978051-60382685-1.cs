    public class C2 : IA2, IB2
    {
        private readonly IA2 _a2;
        private readonly IB2 _b2;
    
        public C2(IA2 a2, IB2 b2)
        {
            _a2 = a2;
            _b2 = b2;
        }
    
        public void f()
        {
            _a2.f();
        }
    
        public void h1()
        {
            _a2.h1();
        }
    
        public void g()
        {
            _b2.g();
        } 
    
        public void h2()
        {
            _b2.h2();
        } 
    }
