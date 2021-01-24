    public class GameBoard 
    {
        public GameBoard(int subGridSize)
        {
            this.SubGridSize = subGridSize;
            this.SubGridCount = subGridSize*subGridSize;
            this.Elements = new int[subGridSize*subGridSize*subGridSize*subGridSize];
        }
        public int SubGridSize { get; }
        public int SubGridCount { get; }
        int[] Elements { get; }
        public int this[int row, int col]
        {
            get => Elements[SubGridCount*row+col];
            set => Elements[SubGridCount*row+col] = value;
        }
        public int this[int grid_row, int grid_col, int row, int col]
        {
            get => Elements[SubGridCount*(grid_row*SubGridSize+row) + grid_col*SubGridSize + col];
            set => Elements[SubGridCount*(grid_row*SubGridSize+row) + grid_col*SubGridSize + col] = value;
        }
        // Make a copy of the elements
        public int[] ToArray() => Elements.Clone() as int[];
        public int[] GetSubArray(int grid_row, int grid_col)
        {
            var array = new int[SubGridCount];
            for (int i = 0; i < SubGridSize; i++)
            {
                var first_element = SubGridCount * (grid_row*SubGridSize+i) + grid_col* SubGridSize;
                for (int j = 0; j < SubGridSize; j++)
                {
                    array[i*SubGridSize + j] = Elements[first_element +j];
                }
            }
            return array;
        }
    }
