	private static IEnumerable<T> RealGenerate<T>(this Func<T> generator) where T : class
	{
	  if (generator == null)
	    yield break;
	  T t;
	  while ((t = generator()) != null)
	    yield return t;
	}
	public static IEnumerable<T> Generate<T>(this Func<T> generator) where T: class
	{
	  Contract.Ensures(Contract.Result<IEnumerable<T>>() != null);
	  Contract.Ensures(Contract.ForAll(Contract.Result<IEnumerable<T>>(), item => item != null));
	  var result = RealGenerate(generator);
	  Contract.Assume(result != null);
	  Contract.Assume(Contract.ForAll(result, item => item != null));
	  return result;
	}
