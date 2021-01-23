	public class SimpleClass
	{
		public virtual DTask<bool> Solve(int n, DEvent<bool> callback)
		{
			for (int m = 2; m < n - 1; m += 1)
				if (m % n == 0)
					return false;
			return true;
		}
	}
	public class DistributedClass : SimpleClass
	{
		public override DTask<bool> Solve(int n, DEvent<bool> callback)
		{
			CodeToExecuteBefore();
			return base.Solve(n, callback);
		}
	}
	// at runtime
	MyClass myInstance;
	if (CodeMustBeAdded && distributed)
		myInstance = new DistributedClass();
	else
		myInstance = new SimpleClass();
	
	
