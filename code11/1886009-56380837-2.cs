    public class Foo
    {
    	public string Date { get; set; }
    	public double Value { get; set; }
    	public double SomeOtherValue { get; set; }
    }
    var apiResponseContent = await response.Content.ReadAsAsync<ApiResponse>();
    var actualData = MapTo<Foo>(apiResponseContent);
