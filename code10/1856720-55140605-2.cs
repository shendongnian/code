	class Program
	{
	    static void Main(string[] args)
	    {
	        Action Execute = delegate { };
	
	        ProgramTest prog = new ProgramTest(h => Execute += h, h => Execute -= h);
	
	        var subscription = prog.AddMethod();
	
	        Execute();
			
			subscription.Dispose();
	    }
	}
	
	class ProgramTest
	{
	    public Action<Action> _attach;
	    public Action<Action> _detach;
	
	    public ProgramTest(Action<Action> attach, Action<Action> detach)
	    {
	        _attach = attach;
			_detach = detach;
	    }
	
	    public IDisposable AddMethod()
	    {
	        _attach(Print);
			return Disposable.Create(() => _detach(Print));
	    }
	
	    public void Print()
	    {
	        Console.WriteLine("test");
	        Console.ReadLine();
	    }
	}
	
	public sealed class Disposable : IDisposable
	{
		public static IDisposable Create(Action action)
			=> new Disposable(action);
			
		private readonly Action _action;
		private int _disposed;
	
		private Disposable(Action action)
		{
			_action = action;
		}
	
		public void Dispose()
		{
			if (Interlocked.Exchange(ref _disposed, 1) == 0)
			{
				_action();
			}
		}
	}
