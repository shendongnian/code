private static bool IsGenericEnumerable(this [NotNull] Type type) =>
            typeof(IEnumerable<>).IsAssignableFrom(type)
            || typeof(IEnumerable<object>).IsAssignableFrom(type)
            || (typeof(IEnumerable<char>).IsAssignableFrom(type) && type != typeof(string))
            || typeof(IEnumerable<byte>).IsAssignableFrom(type)
            || typeof(IEnumerable<sbyte>).IsAssignableFrom(type)
            || typeof(IEnumerable<ushort>).IsAssignableFrom(type)
            || typeof(IEnumerable<short>).IsAssignableFrom(type)
            || typeof(IEnumerable<uint>).IsAssignableFrom(type)
            || typeof(IEnumerable<int>).IsAssignableFrom(type)
            || typeof(IEnumerable<ulong>).IsAssignableFrom(type)
            || typeof(IEnumerable<long>).IsAssignableFrom(type)
            || typeof(IEnumerable<float>).IsAssignableFrom(type)
            || typeof(IEnumerable<double>).IsAssignableFrom(type)
            || typeof(IEnumerable<decimal>).IsAssignableFrom(type)
            || typeof(IEnumerable<DateTime>).IsAssignableFrom(type);
...but that's kind of horrible and I hope there's a better way.
