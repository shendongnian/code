    public class SpatialDictionary<T> : IEnumerable<T>
    {
        private readonly Dictionary<(int, int), List<T>> _dictionary;
        private readonly double _squareSize;
        private readonly Func<T, (double, double)> _locationSelector;
        private int _count;
        public int Count => _count;
        public SpatialDictionary(
            double squareSize, Func<T, (double, double)> locationSelector)
        {
            if (squareSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(squareSize));
            _squareSize = squareSize;
            _locationSelector = locationSelector
                ?? throw new ArgumentNullException(nameof(locationSelector));
            _dictionary = new Dictionary<(int, int), List<T>>();
        }
        public void Add(T item)
        {
            var (itemX, itemY) = _locationSelector(item);
            int keyX = checked((int)(itemX / _squareSize));
            int keyY = checked((int)(itemY / _squareSize));
            if (!_dictionary.TryGetValue((keyX, keyY), out var bucket))
            {
                bucket = new List<T>(1);
                _dictionary.Add((keyX, keyY), bucket);
            }
            bucket.Add(item);
            _count++;
        }
        public T FindClosest(double x, double y)
        {
            if (_count == 0) throw new InvalidOperationException();
            int keyX = checked((int)(x / _squareSize));
            int keyY = checked((int)(y / _squareSize));
            double minDistance = Double.PositiveInfinity;
            T minItem = default;
            int radius = 0;
            while (true)
            {
                checked { radius++; }
                foreach (var square in GetSquares(keyX, keyY, radius))
                {
                    if (!_dictionary.TryGetValue(square, out var bucket)) continue;
                    foreach (var item in bucket)
                    {
                        var (itemX, itemY) = _locationSelector(item);
                        var distX = x - itemX;
                        var distY = y - itemY;
                        var distance = Math.Abs(distX * distX + distY * distY);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            minItem = item;
                        }
                    }
                }
                if (minDistance != Double.PositiveInfinity) return minItem;
            }
        }
        private IEnumerable<(int, int)> GetSquares(int x, int y, int radius)
        {
            if (radius == 1) yield return (x, y);
            for (int i = -radius; i < radius; i++)
            {
                yield return checked((x + i, y + radius));
                yield return checked((x - i, y - radius));
                yield return checked((x + radius, y - i));
                yield return checked((x - radius, y + i));
            }
        }
        public IEnumerator<T> GetEnumerator()
            => _dictionary.Values.SelectMany(b => b).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
