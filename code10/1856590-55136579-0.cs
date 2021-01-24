	void Main()
	{
		Console.WriteLine(Constants.sampleList.Contains(1));
	}
	
	public static class Constants
	{
	    public static string sampleString= "";
	    public static List<int> sampleList= new List<int> {1,2,3};
	}
