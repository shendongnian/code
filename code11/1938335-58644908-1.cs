    public class MyData
	{
	  public string Field1 { get; set; }
	  public string Field2 { get; set; }
	  public bool HasProperty(string propertyName)
	  {
		return GetType().GetProperty(propertyName) != null;
	  }
	}
