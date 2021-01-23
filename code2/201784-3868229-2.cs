    interface IBar
    {
        void Invoke<T>(T t);
    }
    void foo(IBar bar)
    {
        bar.Invoke("hello");
        bar.Invoke(42);
    }
    class BarType : IBar
    {
        public void Invoke<T>(T t)
        {
            // ...
        }
    }
    foo(new BarType());
