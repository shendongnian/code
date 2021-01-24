    public class Foo<T> where T : IEnumerable, new()
    {
        private List<T> fooBarList = new List<T>();
        public Foo()
        {
            Bar1();
            Bar2();
            Bar3();
        }
        public void Bar1()
        {
            T t = default(T);
            fooBarList.Add(t);
        }
        public void Bar2()
        {
            fooBarList.Add(new T());
        }
        public void Bar3() 
        {
            T t = Activator.CreateInstance<T>();
            fooBarList.Add(t);
        }
    }
