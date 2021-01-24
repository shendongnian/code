    public class Class1or2Wrapper
    {
        private Class1 c1;
        private Class2 c2;
        public Class1or2Wrapper(Class1 c1)
        {
            this.c1 = c1;
        }
        public Class1or2Wrapper(Class2 c2)
        {
            this.c2 = c2;
        }
        
        public string AAAAA
        {
            get
            {
                if (this.c1 != null)
                    return c1.AAAAA;
                if (this.c2 != null)
                    return c2.AAAAA;
                return null;
            }
        }
    }
