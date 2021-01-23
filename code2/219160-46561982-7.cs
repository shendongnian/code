	public static class ArrayFactory
	{
		public static TArrayType CreateArrayInitializedWithEmptyStrings<TArrayType>(
				params int[] dimensionLengths) where TArrayType : class
		{
			var array = Array.CreateInstance(typeof(string), dimensionLengths);
			foreach (var indices in CartesianProduct(dimensionLengths))
				array.SetValue(string.Empty, indices.ToArray());
	
			return (array as TArrayType);
		}
	
		private static IEnumerable<IEnumerable<int>> CartesianProduct(params int[] dimensions)
		{
			return CartesianProductImpl(Enumerable.Empty<int>(), dimensions);
	
			IEnumerable<IEnumerable<int>> CartesianProductImpl(
                IEnumerable<int> leftIndices, params int[] dims)
			{
				if (dims.Length == 0)
				{
					yield return leftIndices;
					yield break;
				}
	
				for (int i = 0; i < dims[0]; i++)
					foreach (var elem in CartesianProductImpl(leftIndices.Concat(new[] { i }),
                             dims.Skip(1).ToArray()))
						yield return elem;
			}
		}
	}
