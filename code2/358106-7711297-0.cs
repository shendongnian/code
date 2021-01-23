    class Program {
            static void Main(string[] args) {
    
                int[,] x = { { 1, 2, 3 }, { 4, 5, 6 } };
                int[,] y = { { 7, 8, 9 }, { 10, 11, 12 } };
    
                var xy = new StitchMatrix<int>(x, y);
    
                Console.WriteLine("0,0=" + xy[0, 0]);
                Console.WriteLine("1,1=" + xy[1, 1]);
                Console.WriteLine("1,2=" + xy[1, 2]);
                Console.WriteLine("2,2=" + xy[2, 2]);
            }
        }
    
        class StitchMatrix<T> {
            private T[][,] _matrices;
    
            public StitchMatrix(params T[][,] matrices) {
                // TODO: check they're all same size          
                _matrices = matrices;
            }
    
            public T this[int x, int y]{
                get {
                    int iMatrix = 0;
                    while (_matrices[iMatrix].GetUpperBound(0) < x) {
                        x -= _matrices[iMatrix].GetUpperBound(0);
                        iMatrix++;
                    }
                    return _matrices[iMatrix][x, y];
                }
            }
        }
