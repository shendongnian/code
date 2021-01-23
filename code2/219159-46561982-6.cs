	public static class ArrayFactory
	{
		public static TArrayType CreateArrayInitializedWithEmptyStrings<TArrayType>(
			params int[] dimensionLengths) where TArrayType : class
		{
			var dimensions = dimensionLengths.Select(l => Enumerable.Range(0, l));
			var array = Array.CreateInstance(typeof(string), dimensionLengths);
			foreach (var indices in CartesianProduct(dimensions))
				array.SetValue(string.Empty, indices.ToArray());
	
			return (array as TArrayType);
		}
	
		private static IEnumerable<IEnumerable<T>> CartesianProduct<T>(
		IEnumerable<IEnumerable<T>> dimensions)
		{
			return dimensions.Aggregate(
				(IEnumerable<IEnumerable<T>>)new T[][] { new T[0] },
				(acc, input) =>
					from prevDimension in acc
					from item in input
					select prevDimension.Concat(new T[] { item }));
		}
	}
