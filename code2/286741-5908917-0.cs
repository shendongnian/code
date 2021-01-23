	public class BaseFoo<T> where T : class
	{
		private bool _myProp = false;
		public T SetMyProperty()
		{
			this._myProp = true;
			return this as T;
		}
	}
        public class DerivedFoo : BaseFoo<DerivedFoo> { ... }
