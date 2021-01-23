        public class Test
        {
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
