    public class TwoDList<T> : List<List<T>>
    {
        public T this[int row, int column]
        {
          get { return (this[row])[column]; }
        }
    }
    TwoDList<int> target = new TwoDList<int>();
    var linearSequecValue = target[0, 2];
