    class A
    {
        private int b;
        private int Call(int m, int n)
        {
            return m + n;
        }
        private void Method()
        {
            int a = 5;
            a += 5;
            Func<int> lambda = () => Call(a, b);
            Console.WriteLine(lambda());
        }
        #region compiler rewrites Method to RewrittenMethod and adds nested class X
        private class X
        {
            private readonly A _parentRef;
            public int a;
            public X(A parentRef)
            {
                _parentRef = parentRef;
            }
            public int Lambda()
            {
                return _parentRef.Call(a, _parentRef.b);
            }
        }
        private void RewrittenMethod()
        {
            X x = new X(this);
            x.a += 5;
            Console.WriteLine(x.Lambda());
        }
        #endregion
    }
