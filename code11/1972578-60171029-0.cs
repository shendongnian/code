csharp
void Main()
{
	string testJSON = @"[{""FirstName"":""Michael"",""LastName"":""Jones""},{""FirstName"":""Jon"",""LastName"":""Smith""}]";
	PersonModel[] people = JsonConvert.DeserializeObject<PersonModel[]>(testJSON);
	people.Dump();
}
public class PersonModel
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string GUID { get; set; }
	[DefaultValue(100)] //lets be generous when starting our loyalty program!
	[JsonProperty("LoyaltyPoints", DefaultValueHandling = DefaultValueHandling.Populate)]
	public int LoyaltyPoints { get; set; }
}
And here is a screenshot of the dump:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/YsEBH.png
