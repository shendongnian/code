    public class ArrayND<T>
    {
        private int[] _lengths;
        private Array _array;
        public ArrayND(int[] length)
        {
            _lengths = length;
            _array = Array.CreateInstance(typeof(T), _lengths);
        }
        public T GetValue(int[] index) => (T)_array.GetValue(index);
        public void SetValue(T value, int[] index) => _array.SetValue(value, index);
        public T[] ToOneD() => _array.Cast<T>().ToArray();
        public static ArrayND<T> FromOneD(T[] array, int[] lengths)
        {
            if (array.Length != lengths.Aggregate((i, j) => i * j))
                throw new ArgumentException("Number of elements in source and destination arrays does not match.");
            var factors = lengths.Select((item, index) => lengths.Skip(index).Aggregate((i, j) => i * j)).ToArray();
            var factorsHelper = factors.Zip(factors.Skip(1).Append(1), (Current, Next) => new { Current, Next }).ToArray();
            var res = new ArrayND<T>(lengths);
            for (var i = 0; i < array.Length; i++)
                res.SetValue(array[i],
                             factorsHelper.Select(item => i % item.Current / item.Next).ToArray());
            return res;
        }
        public override bool Equals(object obj) =>
            (obj is ArrayND<T> ndArray) &&
            _lengths.SequenceEqual(ndArray._lengths) &&
            _array.Cast<T>().SequenceEqual(ndArray._array.Cast<T>());
        public override int GetHashCode() =>
            new[] { 17 }
            .Concat(_lengths.Select(i => i.GetHashCode()))
            .Concat(_array.Cast<T>().Select(i => i.GetHashCode()))
            .Aggregate((i, j) => unchecked(23 * i + j));
    }
