    public class MinMaxAggregator
    {
        private bool _any;
        private int _min;
        private int _max;
        public void OnNext(int value)
        {
            if (!_any)
            {
                _min = _max = value;
                _any = true;
            }
            else
            {
                if (value < _min) _min = value;
                if (value > _max) _max = value;
            }
        }
        public MinMax GetResult()
        {
            if (!_any) throw new InvalidOperationException("Sequence contains no elements.");
            return new MinMax(_min, _max);
        }
    }
    public static MinMax DoSomething(IEnumerable<int> source)
    {
        var aggr = new MinMaxAggregator();
        foreach (var item in source) aggr.OnNext(item);
        return aggr.GetResult();
    }
