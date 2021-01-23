    public class barBaseBase
    {
        protected int x = 5;
        public barBaseBase()
        {
            x = 4;
        }
    }
    public class barBase : barBaseBase
    {
        protected int y = 4;
        public barBase()
        {
            x = 3;
            y = 2;
        }
    }
    public class Bar : barBase
    {
        protected int z = 3;
        public Bar()
        {
            x = 2;
            y = 1;
            z = 0;
        }
    }
