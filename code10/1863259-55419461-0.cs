    public static IEnumerable<T> GetRow<T>(this Array source, int dimension, params int[] fixedDimensions)
    {
        if(source == null) throw new ArgumentNullException(nameof(source));
        if(!typeof(T).IsAssignableFrom(source.GetType().GetElementType()) throw new OperationException("Array must be of type T");
        if(fixedDimensions == null) fixedDimensions = new T[0];
        if(source.Rank != fixedDimensions.Length + 1) throw new ArgumentException("Fixed dimensions must have exactly one fewer elements than dimensions in source", nameof(fixedDimensions));
        var coords = fixedDimensions
            .Take(dimension)
            .Concat(new [] { 0 })
            .Concat(fixedDimensions.Skip(dimension))
            .ToArray();
        var length = source.GetLength(dimension);
        for(; coords[dimension] < length; coords[dimension]++)
        {
            yield return (T)source.GetValue(coords);
        }
    }
