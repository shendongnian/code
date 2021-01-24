    public class SubGrid 
    {
        public SubGrid(int size)
        {
            this.Size = size;
            this.Elements = new int[size*size];
        }
        public SubGrid(int size, int[] elements)
        {
            this.Size = size;
            this.Elements  = elements;
        }
        public int Size { get; }
        public int[] Elements { get; }
        public int this[int row, int col]
        {
            get => Elements[Size*row+col];
            set => Elements[Size*row+col] = value;
        }
        public int[] ToArray() => Elements.Clone() as int[];
        public override string ToString()
        {
            const int col_size = 3;
            // print the grid
            var sb = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                var row = Elements.Skip(i*Size).Take(Size);
                sb.AppendLine(string.Join(" ", row.Select((x) => $"{x,-col_size}")));
            }
            return sb.ToString();
        }
    }
