    public class HomeController : ControllerBase
    {
    	public class InputDTO
    	{
    		public string Title { get; set; }
    		public System.Text.Json.JsonElement Stuff { get; set; }
    	}
    
    	[HttpPost]
    	[Route("")]
    	public void Post([FromBody] InputDTO data)
    	{
    		var rawSuffJson = data.Stuff.ToString();
    	}
    }
