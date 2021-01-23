	abstract class UntypedThing { }
	class Thing<T> : UntypedThing
	{
		public Thing(T t) { }
	}
	class Foo
	{
		public static UntypedThing createThing(bool flag)
		{
			if (flag)
				return new Thing<int>(5);
			else return new Thing<String>("hello");
		}
	}
