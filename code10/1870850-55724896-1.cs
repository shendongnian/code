        public class BoleanMatrix
        {
            private int _highBitCount = 0;
            public bool this[int i, int j] 
            {
                get;
                set
                {
                    if(prev != value)
                    { 
                        if(value)
                            _highBitCount++;
                        else
                            _highBitCount--;
                    }
                    //set here
                 }
            }
        }
