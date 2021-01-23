	void Main()
	{
		var a = new SomeEntity{ Id = 1 };
		var b = new SomeEntity{ Id = 2 };
		
		Task.Run(() => DoSomething(a));    
		Task.Run(() => DoSomething(a));    
		Task.Run(() => DoSomething(b));    
		Task.Run(() => DoSomething(b));
	}
	
	ConcurrentDictionary<int, object> _locks = new ConcurrentDictionary<int, object>();    
	void DoSomething(SomeEntity entity)
	{	
		var mutex = _locks.GetOrAdd(entity.Id, id => new object());
		
		lock(mutex)
		{
			Console.WriteLine("Inside {0}", entity.Id);
            // do some work
		}
	}	
