	public class Worker<A> 
		where A : new()
	{
		public A req;
		public void DoSomeMeaningfulWork()
		{
			req.Header = new SomeHeader();
			req.Parameters = new SomeParamaters();
		}
	}
