	public class JSonEqualityComparer<T> : IEqualityComparer<T>
	{	
		public bool Equals(T x, T y)
		{			
			return String.Equals
			( 
				Newtonsoft.Json.JsonConvert.SerializeObject(x), 
				Newtonsoft.Json.JsonConvert.SerializeObject(y)
			);					
		}
		public int GetHashCode(T obj)
		{							
			return Newtonsoft.Json.JsonConvert.SerializeObject(obj).GetHashCode();			
		}				
	}		
	public static partial class LinqExtensions
	{
		public static IEnumerable<T> ExceptUsingJSonCompare<T>
            (this IEnumerable<T> first, IEnumerable<T> second)
		{	
			return first.Except(second, new JSonEqualityComparer<T>());
		}
	}
