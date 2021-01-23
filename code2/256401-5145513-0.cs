    internal class MyGenericClass<T> where T : IComparable
    {
        private T[] data;
        public void AddData(T[] values)
        {
            data = values;
        }
        public int FindValue<T>(T value)
        {
            return data.Count(v => v.CompareTo(value) == 0);
        }
    }
