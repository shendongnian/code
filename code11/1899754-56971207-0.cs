    public static void Main(string[] args) {
    
        int[,] _tacToe = new int[3, 3] {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
    
        for (int row = 0; row < 3; row++) {
    
            for (int columm = 0; columm < 3; columm++) {
                Console.Write(_tacToe[row, columm]);
            }
            Console.WriteLine();
        }
    
        Console.ReadLine();
    }
