    public class JaggedArray : IEnumerable<int>
    {
        private int[][] array;
        public JaggedArray(int[][] array)
        {
            this.array = array;
        }
        public int this[int row, int column]
        {
            get { return array[row][column]; }
            set { array[row][column] = value; }
        }
        public IEnumerable<int[]> Rows
        {
            get { return array; }
        }
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var row in array)
                foreach (var item in row)
                    yield return item;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
