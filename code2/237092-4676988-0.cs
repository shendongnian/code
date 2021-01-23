        class A<T>
        {
            public virtual event EventHandler e;
        }
        
        class Aadapter<T1, T2> : A<T1> 
        { 
            A<T2> a; 
            Aadapter(A<T2> _a) { a = _a; } 
            public override event EventHandler  e
            {
                add { a.e += value; }
                remove { a.e -= value; }
            }
        }
