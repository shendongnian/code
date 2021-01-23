	abstract class AbstractBase<T>
	{
		public static String AbstractStaticProp { get; set; }
	};
	class Derived1 : AbstractBase<Derived1>
	{
		public static new String AbstractStaticProp
		{
			get => AbstractBase<Derived1>.AbstractStaticProp;
			set => AbstractBase<Derived1>.AbstractStaticProp = value;
		}
	};
	class Derived2 : AbstractBase<Derived2>
	{
		public static new String AbstractStaticProp
		{
			get => AbstractBase<Derived2>.AbstractStaticProp;
			set => AbstractBase<Derived2>.AbstractStaticProp = value;
		}
	};
