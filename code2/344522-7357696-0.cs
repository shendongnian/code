	public class BaseEnum<E> where E : BaseEnum<E>, new()
	{
		public static readonly E A = new E() { Name = "A" };
		public static readonly E B = new E() { Name = "B" };
		public static readonly E C = new E() { Name = "C" };
	
		public string Name { get; protected set; }
		
		protected static IEnumerable<E> InternalValues
		{
			get
			{
				yield return A;
				yield return B;
				yield return C;
			}
		}
	}
	
	public class BaseEnum : BaseEnum<BaseEnum>
	{
		public static IEnumerable<BaseEnum> Values
		{
			get { foreach (var x in InternalValues) yield return x; }
		}
	}
	
	public class ChildEnum : BaseEnum<ChildEnum>
	{
		public static readonly ChildEnum D = new ChildEnum() { Name = "D" };
		public static readonly ChildEnum E = new ChildEnum() { Name = "E" };
	
		public static IEnumerable<ChildEnum> Values
		{
			get
			{
				foreach (var x in InternalValues) yield return x;
				yield return D;
				yield return E;
			}
		}
	}
