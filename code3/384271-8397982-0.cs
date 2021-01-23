        public int Test()
        {
            TwoDList<int> target = new TwoDList<int>();
            target.Add(new List<int>(new int[] {3,5,6}));
            target.Add(new List<int>(new int[] {2,1,8}));
            target.Add(new List<int>(new int[] {1,3,4}));
            return target[1, 2];
        }
    }
    public class TwoDList<T> : List<List<T>>
    {
        public T this[int row, int column]
        {
            get { return this[row][column]; }
            set { this[row][column] = value; }
        }
    }
