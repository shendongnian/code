    public static void Main(ref System.String msg)
	{
		var result = Foo(msg).GetAwaiter().GetResult();
        msg = result;
	}
	
	private static async Task<string> Foo(string msg)
	{   
		await Task.Delay(3000).ConfigureAwait(false);
		return "UPDATED";
	}
