	class Generic<T>
	{
		protected T value;
		public Generic(T val)
		{
			value = val;
		}
	}
	class Generic_float : Generic<float>
	{
		public Generic_float(float val)
			: base(val)
		{
		}
		public void Add()
		{
			value = value + 1.0f;
		}
	}
