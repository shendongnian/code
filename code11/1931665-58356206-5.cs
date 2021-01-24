    public class SortColorByRed : IComparer<Color>
    {
        public int Compare(Color x, Color y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            return x.R.CompareTo(y.R);
        }
    }
