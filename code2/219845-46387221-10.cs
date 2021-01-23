        [AttributeUsage(AttributeTargets.Class, AllowMultiple =false)]
        public class MyAttribute : ValidationAttribute
        {
       	    AlgorithmTypes AlgorithmType;
			
			public MyAttribute(AlgorithmTypes algorithm = AlgorithmTypes.None)
			{
				AlgorithmType = algorithm;
			}
			public override bool IsValid(object value)
			{
				return (AlgorithmStrategyFactory.Create(AlgorithmType)).IsValid(Properties, value);
			}
		}    
