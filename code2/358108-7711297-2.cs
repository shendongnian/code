    class Program {
            static void Main(string[] args) {
    
                int[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };
                int[,] b = { { 7, 8, 9 }, { 10, 11, 12 } };
    
                var ab = new StitchMatrix<int>(a, b);
    
                Console.WriteLine("0,0=" + ab[0, 0]); // 1
                Console.WriteLine("1,1=" + ab[1, 1]); // 5
                Console.WriteLine("1,2=" + ab[1, 2]); // 6
                Console.WriteLine("2,2=" + ab[2, 2]); // 9
                Console.WriteLine("3,2=" + ab[3, 2]); // 12
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
                        x -= (_matrices[iMatrix].GetUpperBound(0)+1);
                        iMatrix++;
                    }
                    return _matrices[iMatrix][x, y];
                }
            }
        }
