    public class Matrix
    {
        int Width;
        List<int[]> dataset = new List<int[]>();
        public Matrix(int ColumnCount)
        {
            Width = ColumnCount;
        }
        public void addrow(int[] row)
        {
            //intelligence here to make sure the row length is correct
            dataset.Add(row);
        }
    }
