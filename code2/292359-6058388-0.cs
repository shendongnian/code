	class Program
	{
		public static void Main(string[] args)
		{
			CCInfo ccInfo = new CCInfo();
			UCInfo ucInfo = new UCInfo();
			IBaseInfo<BaseDecision> x = ccInfo;
			x = ucInfo;
		}
		public class BaseDecision
		{
			// <implementation> 
		}
		public class CCDecision : BaseDecision
		{
			// <implementation> 
		}
		public class UCDecision : BaseDecision
		{
			// <implementation> 
		}
		public interface IBaseInfo<out TDecision> where TDecision : BaseDecision, new()
		{
			TDecision proposedDecision { get; }
			TDecision finalDecision { get; }
		}
		public abstract class BaseInfo<TDecision> : IBaseInfo<TDecision> where TDecision : BaseDecision, new()
		{
			public TDecision proposedDecision { get; set; }
			public TDecision finalDecision { get; set; }
			// <implementation> 
		}
		public class CCInfo : BaseInfo<CCDecision>
		{
			// <implementation> 
		}
		public class UCInfo : BaseInfo<UCDecision>
		{
			// <implementation> 
		}
	}
