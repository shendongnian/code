    public class Base
	{
		public T Method<T>()where T: Base
		{
			return (T)this;
		}
	}
	public class Derived1 : Base { }
	public class Derived2 : Base { }
	Derived1 d1 = new Derived1();
	Derived1 x = d1.Method<Derived1>();
	Derived2 d2 = new Derived2();
	Derived2 y = d2.Method<Derived2>();
