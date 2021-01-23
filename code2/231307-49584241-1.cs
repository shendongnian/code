    ///                                v---- constraint added      
	abstract class AbstractBase<TSelf> where TSelf : AbstractBase<TSelf>
	{
		public static String AbstractStaticProp { get; set; }
	};
