    public class MyList
    {
        static int _count;
        private int myCount;
        public MyList()
        {
            this.myCount = ++_count;
        }
        public int GetCount()
        {
            return this.myCount;
        }
    }
