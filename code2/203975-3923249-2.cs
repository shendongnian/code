    class IC<A, B>
    {
        public IC(A a, B b)
        {
            Value1 = a;
            Value2 = b;
        }
        public A Value1 { get; set; }
        public B Value2 { get; set; }
    }
    class Signatur : ISignatur<bool>
    {
        public string Test { get; set; }
        public IC<Signatur, ISignatur<bool>> Get()
        {
            return new IC<Signatur, ISignatur<bool>>(this, this);
        }
    }
    class ServiceGate
    {
        public IAccess<C, T> Get4<C, T>(IC<C, ISignatur<T>> control) where C : ISignatur<T>
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
			var bla4 = service.Get4((new Signatur()).Get()); // Better...
		}
	}
