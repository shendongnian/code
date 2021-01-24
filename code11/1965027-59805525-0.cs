    using System;
    using System.Collections.Generic;
    using System.Linq;
    public sealed class MyClass<T>
    {
        List<T> list;
        public MyClass()
        {
            var allowedTypes = new[] { typeof(int), typeof(double), typeof(float) };
            if (!allowedTypes.Contains(typeof(T)))
                throw new Exception($"Type '{typeof(T)}' not supported.");
            list = new List<T>();
        }
        public double Average()
        {
            return list.Cast<double>().Average();
        }
        public void Add(T value)
        {
            list.Add(value);
        }
        public void Reset()
        {
            list.Clear();
        }
    }
