	class CustomObject : Object
	{
		public string SomeData;
	}
	private void setup(string someData)
	{
		CustomObject customObject = new CustomObject { SomeData = someData };
		CustomObject.assignHandler(evHandler);
	}
	public void evHandler(Object sender)
	{
		string someData = ((CustomObject)sender).SomeData;
	}
