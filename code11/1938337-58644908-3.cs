    public class MyData
	{
	  public string Field1 { get; set; }
	  public string Field2 { get; set; }
      
      // this can be extension method also.
	  public bool HasProperty(string propertyName)
	  {
		return GetType().GetProperty(propertyName) != null;
	  }
	}
