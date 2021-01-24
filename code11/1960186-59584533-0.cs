    char[,] arr = new char[4, 4]
        {
            { '☺', '♣', '♦', '♠'},
            { '♥', '♫', '☼', '☺'},
            { '☺', '♣', '♦', '♠'},
            { '♥', '♫', '☼', '☺'},
        };
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);
            Console.Write("\t");
            for (int row =1; row<5; row++)
            {
                Console.Write(string.Format("\t{0}", row));
            }
            Console.Write(Environment.NewLine);
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write(string.Format("\t{0} ", i+1));
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("\t{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
