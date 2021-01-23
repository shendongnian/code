	class ServiceGate
	{
		public IAccess<C, T> Get3<C, T>(C control, ISignatur<T> iControl) where C : ISignatur<T>
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
			var c = new Signatur();
			var bla3 = service.Get3(c, c); // Works!! 
		}
	}
