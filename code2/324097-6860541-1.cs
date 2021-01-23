	public class MyTypeAttributeCommand : IAttributeCommand
	{
		MyDependency dependency;
                SomeOtherDependency otherDependency;
		
		public MyTypeAttributeCommand (MyDependency dependency, ISomeOtherDependency otherDependency)
		{
			this.dependency = dependency;
                        this.otherDependency = otherDependency
		}
		
		public bool Matches(Type type)
		{
			return type==typeof(MyType)
		}
		public void Execute()
		{
			// do action using dependency/dependencies
		}
	}
