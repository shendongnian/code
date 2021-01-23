    public interface IBar
    {
        void Blah(int a, int b);
    }
    public interface IBaz
    {
        void Save(int a, int b);
    }
    public class Foo
    {
        Func<IBar> getBar;
        public Foo(Func<IBar> getBar)
        {
            this.getBar = getBar;
        }
        public void Frob(int a, int b)
        {
            if (a == 1)
            {
                if (b == 1)
                {
                    // does something
                }
                else
                {
                    if (b == 2)
                    {                        
                        getBar().Blah(a, b);
                    }
                }
            }
            else
            {
                // does something
            }
        }
    }
    
    public class Bar : IBar
    {
        Func<IBaz> getBaz;
        public Bar(Func<IBaz> getBaz)
        {
            this.getBaz = getBaz;
        }
        public void Blah(int a, int b)
        {
            if (a == 0)
            {
                // does something
            }
            else
            {
                if (b == 0)
                {
                    // does something
                }
                else
                {
                    getBaz().Save(a, b);
                }
            }
        }
    }
    public class Baz: IBaz
    {
        public void Save(int a, int b)
        {
            // saves data to file, database, whatever
        }
    }
