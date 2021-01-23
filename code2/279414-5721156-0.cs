        class A1<T,U>
        {
            public virtual void Generic(T t, U u) { }
        }
        class A2<T> : A1<T , int>
        {      
            public override void  Generic(T t, int u) { }
        }
