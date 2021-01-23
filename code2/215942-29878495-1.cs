	void Main()
	{
		var a = new SomeEntity{ Id = 1 };
		var b = new SomeEntity{ Id = 2 };
		
		Task.Run(() => DoSomething(a));    
		Task.Run(() => DoSomething(a));    
		Task.Run(() => DoSomething(b));    
		Task.Run(() => DoSomething(b));
	}
	
	void DoSomething(SomeEntity entity)
	{	
		lock(string.Intern("dee9e550-50b5-41ae-af70-f03797ff2a5d:" + entity.Id))
		{
			Console.WriteLine("Inside {0}", entity.Id);
            // do some work
		}
	}
