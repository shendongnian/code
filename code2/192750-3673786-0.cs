    class Class1 : IDisposable
    {
        public List<Class2> Classes;
        public void Dispose()
        {
            foreach(Class2 c in Classes
            {
                c.Dispose();
            }
        }
    }
