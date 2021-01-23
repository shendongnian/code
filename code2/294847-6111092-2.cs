    public class Wrapper<T>
    {
        private readonly T[,] array;
        public Wrapper(T[,] array)
        {
            this.array = array;
        }
        public T this[int x, int y]
        {
            return array[x, y];
        }
        public int Rows { get { return array.GetUpperBound(0); } }
        public int Columns { get { return array.GetUpperBound(1); } }
    }
