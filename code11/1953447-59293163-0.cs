  public class MyDto
  {
      public string Field1 { get; set; }
      public dynamic Json { get; set; } 
  }
when you deserialize, it will convert it to a dynamic object, not a string. 
Ideally, you want to use another object that classifies what the json object is supposed to be
  public class MyJsonObject
  {
    public string Field1OfJson {get;set;}
    public string Field2OfJson {get;set;}
  }
  // Then use that as the type
  public class MyDto
  {
      public string Field1 { get; set; }
      public MyJsonObject Json { get; set; } 
  }
This way you can access the data under Json easily.
