    public class Foo : IDisposable
	{
		IDisposable boo;
		public void Dispose()
		{
			boo?.Dispose();
		}
	}
	public class Bar : Foo
	{
        //Memory leak possible here
		public event EventHandler SomeEvent;
        //Also bad code, but will compile
        public void Dispose()
        {
            someEvent = null;
            //Still bad code even with this line
            base.Dispose();
        }
	}
