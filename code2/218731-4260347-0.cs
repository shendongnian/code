    class A
    {
        static Dictionary<int, A> a = new Dictionary<int, A>();
        static int i = 0;
        int id;
        public A()
        {
            id = ++i;
            a[id] = this;
        }
        protected void Destroy()
        {
            a.Remove(id);
            i--;
        }
        public static int Count() { return a.Count; }
    }
    class B : A
    {
        public B() 
        {
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {
                Destroy();
                throw;
            }
        }
    }
