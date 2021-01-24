    public class C2 : IA2, IB2
    {
        private readonly IA2 _a2;
        private readonly IB2 _b2;
    
        public C2(IA2 a2, IB2 b2)
        {
            _a2 = a2;
            _b2 = b2;
        }
    
        public void f_public()
        {
            _a2.f_public();
        }
    
        public void h1_public()
        {
            _a2.h1_public();
        }
    
        public void g_public()
        {
            _b2.g_public();
        } 
    
        public void h2_public()
        {
            _b2.h2_public();
        } 
    }
