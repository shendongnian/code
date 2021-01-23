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
