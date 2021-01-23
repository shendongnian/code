	/// <summary>
	/// Abstract base class for generic <see cref="Parameter<T1>"/> family of classes
	/// that represent parameters passed to constructors and methods.
	/// </summary>
	/// <remarks>
	/// This class was created due to a desire to support .NET 3.5, which does not
	/// include the <see cref="Tuple"/> class providing similar capabilities
	/// </remarks>
	public abstract class Parameter
	{}
	public class Parameter<T1> : Parameter
	{
		public Parameter(T1 param1)
		{
			this.Param1 = param1;
		}
		public T1 Param1 { get; set; }
	}
	public class Parameter<T1, T2> : Parameter<T1>
	{
		public Parameter(T1 param1, T2 param2)
			: base(param1)
		{
			this.Param2 = param2;
		}
		public T2 Param2 { get; set; }
	}
	public class Parameter<T1, T2, T3> : Parameter<T1, T2>
	{
		public Parameter(T1 param1, T2 param2, T3 param3)
			: base(param1, param2)
		{
			this.Param3 = param3;
		}
		public T3 Param3 { get; set; }
	}
	public class Parameter<T1, T2, T3, T4> : Parameter<T1, T2, T3>
	{
		public Parameter(T1 param1, T2 param2, T3 param3, T4 param4)
			: base(param1, param2, param3)
		{
			this.Param4 = param4;
		}
		public T4 Param4 { get; set; }
	}
	public class Parameter<T1, T2, T3, T4, T5> : Parameter<T1, T2, T3, T4>
	{
		public Parameter(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
			: base(param1, param2, param3, param4)
		{
			this.Param5 = param5;
		}
		public T5 Param5 { get; set; }
	}
	public class Parameter<T1, T2, T3, T4, T5, T6> : Parameter<T1, T2, T3, T4, T5>
	{
		public Parameter(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
			: base(param1, param2, param3, param4, param5)
		{
			this.Param6 = param6;
		}
		public T6 Param6 { get; set; }
	}
	
	public class Parameter<T1, T2, T3, T4, T5, T6, T7> : Parameter<T1, T2, T3, T4, T5, T6>
	{
		public Parameter(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
			: base(param1, param2, param3, param4, param5, param6)
		{
			this.Param7 = param7;
		}
		public T7 Param7 { get; set; }
	}
	public class Parameter<T1, T2, T3, T4, T5, T6, T7, T8> : Parameter<T1, T2, T3, T4, T5, T6, T7>
	{
		public Parameter(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
			: base(param1, param2, param3, param4, param5, param6, param7)
		{
			this.Param8 = param8;
		}
		public T8 Param8 { get; set; }
	}
