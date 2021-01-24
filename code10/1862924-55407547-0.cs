        static Random rnd = new Random();
        static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + rnd.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
        public Game()
        {
            InitializeComponent();
            Label[] puzzles = { puz1, puz2, puz3, puz4, puz5, puz6, puz7, puz8, puz9 };
            string[] puz = { "1", "2", "3", "4", "5", "6", "7", "8" };
            Shuffle(puz);
            for (int i = 0; i < puzzles.Length - 1; i++)
            {
                puzzles[i].Text = puz[i];
            }
        }
