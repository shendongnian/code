    public static string[,] updateGameBoard(string[,] matrix, int selection, Player p)
        {
            switch (selection)
            {
                case 1:
                    matrix[0, 0] = p.Type;
                    p.Sequence[0][0] = 1;
                    p.TrackCol[0][0] = 1;
                    break;
                case 2:
                    matrix[0, 1] = p.Type;
                    p.Sequence[0][1] = 2;
                    p.TrackCol[0][0] = 2;
                    break;
                case 3:
                    matrix[0, 2] = p.Type;
                    p.Sequence[0][2] = 3;
                    p.TrackCol[0][0] = 3; 
                    break;
                case 4:
                    matrix[1, 0] = p.Type;
                    p.Sequence[1][0] = 4;
                    p.TrackCol[0][1] = 4;
                    break;
                case 5:
                    matrix[1, 1] = p.Type;
                    p.Sequence[1][1] = 5;
                    p.TrackCol[0][1] = 5; 
                    break;
                case 6:
                    matrix[1, 2] = p.Type;
                    p.Sequence[1][2] = 6;
                    p.TrackCol[0][1] = 6; 
                    break;
                case 7:
                    matrix[2, 0] = p.Type;
                    p.Sequence[2][0] = 7;
                    p.TrackCol[0][2] = 7;
                    break;
                case 8:
                    matrix[2, 1] = p.Type;
                    p.Sequence[2][1] = 8;
                    p.TrackCol[0][2] = 8; 
                    break;
                case 9:
                    matrix[2, 2] = p.Type;
                    p.Sequence[2][2] = 9;
                    p.TrackCol[0][2] = 9; 
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
