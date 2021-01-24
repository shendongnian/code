	public string Post([FromForm]MyViewModel vm)
	{
		if (vm.file != null)
		{
			return "Success: We got something!!!";
		}
		else
		{
			return "Sadness: We got null :-(";
		}
	}
	public class MyViewModel
	{
		public HttpFile SomeFile { get; set; }
	}
