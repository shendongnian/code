	class ServiceGate
	{
		public IAccess<C, T> Get1<C, T>(C control) where C : ISignatur<T>
		{
			throw new NotImplementedException();
		}
		public IAccess<ISignatur<T>, T> Get2<T>(ISignatur<T> control)
		{
			throw new NotImplementedException();
		}
	}
	class Test
	{
		static void Main()
		{
			ServiceGate service = new ServiceGate();
			//var bla1 = service.Get1(new Signatur()); // CS0411
			var bla = service.Get2(new Signatur()); // Works
		}
	}
