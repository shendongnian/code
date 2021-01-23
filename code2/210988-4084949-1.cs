     public struct EmbeddedArray<T>
        {
            private T _element0;
            private T _element1;
            private T _element2;
    
            public int Length { get { return 3; } }
    
    
            public T this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return _element0;
                        case 1:
                            return _element1;
                        case 2:
                            return _element2;
                    }
                    throw new ArgumentOutOfRangeException("index");
    
                }
            }
        }
