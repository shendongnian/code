        public class Test
        {
            int _count;
            public int Count
            {
                get
                {
                    _count++;
                    throw new Exception("hello");
                    return _count;
                }
            }
        } 
