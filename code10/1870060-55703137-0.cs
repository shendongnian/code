public class Person
{
  public string Name { get; set; }
}
public class People
{
  public string[] Names { get; set; }
}
public static People LoadPeople(string[] personJson)
  => new People
  {
    Names = JsonConvert.Deserialize<Person>(personJson).Select(p => p.Name).ToArray()
  };
