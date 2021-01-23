    class A<T>
    {
        public event EventHandler e;
        
        protected void ChainEvent(object sender, EventArgs eventArgs)
        {
            e(sender, eventArgs);
        }
    }
    class Aadapter<T1, T2> : A<T1> 
    { 
        A<T2> a; 
        Aadapter(A<T2> _a)
        {
            a = _a;
            a.e += ChainEvent;
        }
    }
