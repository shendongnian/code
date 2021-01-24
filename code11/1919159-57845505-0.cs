    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameBoard(3);
            // Fill the board with sequencial number (the index).
            var index = 0;
            for (int i = 0; i < game.SubGridCount; i++)
            {
                for (int j = 0; j < game.SubGridCount; j++)
                {
                    game[i, j] = index++;
                }
            }
            // game = 
            // +----------+----------+----------+
            // |  0  1  2 |  3  4  5 |  6  7  8 |
            // |  9 10 11 | 12 13 14 | 15 16 17 |
            // | 18 19 20 | 21 22 23 | 24 25 26 |
            // +----------+----------+----------+
            // | 27 28 29 | 30 31 32 | 33 34 35 |
            // | 36 37 38 | 39 40 41 | 42 43 44 |
            // | 45 46 47 | 48 49 50 | 51 52 53 |
            // +----------+----------+----------+
            // | 54 55 56 | 57 58 59 | 60 61 62 |
            // | 63 64 65 | 66 67 68 | 69 70 71 |
            // | 72 73 74 | 75 76 77 | 78 79 80 |
            // +----------+----------+----------+
            var data = game.ToArray();
            // [0,1,2,3,4,5...79,80]
            var A11 = game.GetSubArray(0, 0);
            // [0,1,2,9,10,11,18,19,20]
            var A12 = game.GetSubArray(0, 1);
            // [3,4,5,12,13,14,21,22,23]
            var A13 = game.GetSubArray(0, 2);
            // [6,7,8,15,16,17,24,25,25]
            var A32 = game.GetSubArray(2, 1);
            // [57,58,59,66,67,68,75,76,77]
            // In the A23 subgrid, get the (3,1) element
            var x2331 = game[1, 2, 2, 0];
            // 51
        }
    }
