	static JumpBuffer buf = new JumpBuffer();
	
	static void second()
	{
		Console.WriteLine("second");
		try{
			buf.Jump(1);
		}finally{
			Console.WriteLine("finally");
		}
	}
		
	static void first()
	{
		second();
		Console.WriteLine("first");
	}
	
	public static void Main(string[] args)
	{
		buf.Set(
			val => {
				Console.WriteLine(val);
				if(val == 0) first();
				else Console.WriteLine("main");
			}
		);
		
		Console.ReadKey(true);
	}
