	public class PcUsernameScore : Pair<object, string, float> {}
	public class Pair<T1, T2, T3>
	{
		public Pair(T1 value1, T2 value2, T3 value3)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
		}
		public T1 Value1;
		public T2 Value2;
		public T3 Value3;
	}
