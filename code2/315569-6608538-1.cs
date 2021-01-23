	public class StaticReflectionFacts
	{
		public class X2
		{
		}
		public class X
		{
			public X( object param1, X2 param2 )
			{
			}
		}
		[Fact]
		static void DeriveNinjectConstructorArgumentFromPublic()
		{
			ConstructorArgument newArg = StaticReflection<X>.CreateConstructorArgument( new X2() );
			Assert.Equal( "param2", newArg.Name );
		}
	}
