	class Program
	{
	    static void Main(string[] args)
	    {
	        Action Execute = delegate { };
	
	        MetaAction meta = MetaAction.Create(h => Execute += h, h => Execute -= h);
	
			var prog = new ProgramTest(meta);
			
	        var subscription = prog.AddMethod();
	
	        Execute();
			
			subscription.Dispose();
	    }
	}
	
	public class MetaAction
	{
		public static MetaAction Create(Action<Action> attach, Action<Action> detach)
			=> new MetaAction(attach, detach);
			
	    public Action<Action> _attach;
	    public Action<Action> _detach;
	
	    private MetaAction(Action<Action> attach, Action<Action> detach)
	    {
	        _attach = attach;
			_detach = detach;
	    }
	
	    public IDisposable Subscribe(Action action)
	    {
	        _attach(action);
			return Disposable.Create(() => _detach(action));
		}
	}
	
	public class ProgramTest
	{
	    public MetaAction _meta;
	    	
	    public ProgramTest(MetaAction meta)
	    {
	        _meta = meta;
	    }
	
	    public IDisposable AddMethod()
	    {
	        return _meta.Subscribe(Print);
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
