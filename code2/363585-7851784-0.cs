	class ThreadLocalData
	{
		public int GlobalInt { get; set; }
		public string GlobalString { get; set; }
	}
	class Global
	{
		static ThreadLocal<ThreadLocalData> _ThreadLocal =
            new ThreadLocal<ThreadLocalData>( () => new ThreadLocalData() );
		public static ThreadLocalData ThreadLocal
        {
           get { return _ThreadLocal.Value; }
        }
	}
