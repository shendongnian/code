        public class UnitTest1
    {
        int ROWS = 5;
        int COLS = 6;
        public class GamePiece
        {
            public int Width;
            public string Color;
            public int Address;
            public int Offset;
        }
        public class GameRow
        {
            public List<GamePiece> Row = new List<GamePiece>();
        }
        private void initializeBoard(GamePiece[] board) {
            for(int i = 1; i < board.Length; i++) board[i] = EmptyPiece(i);
        }
        private GamePiece EmptyPiece(int address)
        {
            return new GamePiece
            {
                Address = address,
                Width = 1,
                Color = "Gray",
                Offset = 0
            };
        }
        private int ComputeRow(int address)
        {
            return ((address - 1) / COLS);
        }
        private void processDictionary(GamePiece[] board, Dictionary<int,GamePiece> d)
        {
            foreach (var piece in d.Values)
            {
                for (int i = 0; i < piece.Width; i++)
                {
                    board[piece.Address - piece.Offset + i] = null;
                }
                board[piece.Address] = piece;
            }
        }
        private GameRow[] convertBoardtoRows(GamePiece[] board)
        {
            var rows = new GameRow[ROWS];
            for (int i = 0; i < rows.Length; i++) rows[i] = new GameRow();
            for (int i = 1; i < board.Length; i++)
            {
                if (board[i] != null)
                {
                    rows[ComputeRow(i)].Row.Add(board[i]);
                }
            }
            return rows;
        }
        public GameRow[] ProcessPieces(Dictionary<int, GamePiece> dictionary)
        {
            GamePiece[] board = new GamePiece[ROWS*COLS+1];
            initializeBoard(board);
            processDictionary(board, dictionary);
            return convertBoardtoRows(board);
        }
        [TestMethod]
        public void TestMethod1()
        {
            var dictionary = new Dictionary<int, GamePiece>();
            dictionary.Add(1, new GamePiece { Address = 2, Width = 1, Offset = 0, Color = "Yellow" });
            dictionary.Add(2, new GamePiece { Address = 12, Width = 2, Offset = 1, Color = "Yellow" });
            dictionary.Add(3, new GamePiece { Address = 23, Width = 3, Offset = 1, Color = "Yellow" });
            var rows = ProcessPieces(dictionary);
            Assert.IsTrue(rows[0].Row.Count == 6);
            Assert.IsTrue(rows[0].Row.Where(p => p.Color == "Yellow").Count() == 1);
            Assert.IsTrue(rows[0].Row.Where(p => p.Color == "Gray").Count() == 5);
            var piece = rows[0].Row.Where(p => p.Color == "Yellow").First();
            Assert.IsTrue(piece.Address == 2);
            Assert.IsTrue(rows[1].Row.Count == 5);
            Assert.IsTrue(rows[1].Row.Where(p => p.Color == "Yellow").Count() == 1);
            Assert.IsTrue(rows[1].Row.Where(p => p.Color == "Gray").Count() == 4);
            Assert.IsTrue(rows[1].Row.Where(p => p.Address == 11).Count() == 0);
            piece = rows[1].Row.Where(p => p.Color == "Yellow").First();
            Assert.IsTrue(piece.Address == 12);
            Assert.IsTrue(rows[2].Row.Count == 6);
            Assert.IsTrue(rows[2].Row.Where(p => p.Color == "Yellow").Count() == 0);
            Assert.IsTrue(rows[2].Row.Where(p => p.Color == "Gray").Count() == 6);
            Assert.IsTrue(rows[3].Row.Count == 4);
            Assert.IsTrue(rows[3].Row.Where(p => p.Color == "Yellow").Count() == 1);
            Assert.IsTrue(rows[3].Row.Where(p => p.Color == "Gray").Count() == 3);
            Assert.IsTrue(rows[4].Row.Count == 6);
            Assert.IsTrue(rows[4].Row.Where(p => p.Color == "Yellow").Count() == 0);
            Assert.IsTrue(rows[4].Row.Where(p => p.Color == "Gray").Count() == 6);
        }
    }
