    	public class Egg
	{
		private readonly Func<IBird> _createBird;
		private IBird _Bird = null;
		public Egg(Func<IBird> createBird)
		{
			_createBird = createBird;
		}
		public IBird Hatch()
		{
			if (_Bird == null)
			{
				_Bird = _createBird();
			}
			return _Bird;
		}
	}
    
