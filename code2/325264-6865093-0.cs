		public abstract class RiskPolicy
		{
			public abstract RiskFactor Risk { get; }
		}
		public class PointsPolicy : RiskPolicy
		{
			private readonly int _points;
			public PointsPolicy(int points)
			{
				_points = points;
			}
			public override RiskFactor Risk
			{
				get { return _points > 3 ? RiskFactor.HIGH_RISK : 
							 _points > 0 ? RiskFactor.MODERATE_RISK : RiskFactor.LOW_RISK; }
			}
		}
		public class AgePolicy : RiskPolicy
		{
			private readonly int _age;
			public AgePolicy(int age)
			{
				_age = age;
			}
			public override RiskFactor Risk
			{
				get { return _age < 25 ? RiskFactor.HIGH_RISK : RiskFactor.LOW_RISK; }
			}
		}
