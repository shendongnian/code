	public class Factorial<T>
		where T : IConvertible 
		{
			public T GetFactorial(T t)
			{
				int int32 = Convert.ToInt32(t);
				if (int32 == 0)
					return (T) Convert.ChangeType( 1, typeof(T));
				return GetFactorial( (T) Convert.ChangeType(int32-1, typeof(T)) );
			}
		}
