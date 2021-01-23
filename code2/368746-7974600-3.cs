	void Main()
	{
		var now=DateTime.UtcNow;
		var d=new ConcurrentDictionary<DateTime, Lazy<CustomImmutableObject>>();
		Action f=()=>{
			var val=d
				.GetOrAdd(
					now,
					dt => new Lazy<CustomImmutableObject>(
						() => new CustomImmutableObject()
					)
				).Value;
			Console.WriteLine(val);
		};
		for(int i=0;i<10;++i)
		{
			(new Thread(()=>f())).Start();
		}
		Thread.Sleep(15000);
		Console.WriteLine("Finished");
	}
	class CustomImmutableObject
	{
		public CustomImmutableObject()
		{
			Console.WriteLine("CREATING");
			Thread.Sleep(10000);
		}
	}
