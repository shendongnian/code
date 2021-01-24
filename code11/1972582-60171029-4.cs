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
----------
**Update:**
You've yet to give a good reason for doing things the way you're doing it. Instead of storing a JSON object that contains a stringified JSON object, you should be storing something like this:
json
{
    "DebugMode": "true",
    "UseCustomOptions": "false",
    "SelectedMenu": "3",
    "CustomFormats": [],
    "User": {
        "username": "Ole",
        "password": "ole",
        "verifiedStatus": "false",
        "creationTime": "10-02-2020 13:35:13"
    }
}
And your models should look like (obviously I'm guessing a bit here as you don't have all of your code posted):
chsarp
public class Config
{
	public bool DebugMode { get; set; }
	public bool UseCustomOptions { get; set; }
	public int SelectedMenu { get; set; }
	public List<ZXing.BarcodeFormat> CustomFormats { get; set; }
	public User User { get; set; }
}
public class User 
{
	public string Username { get; set; }
	public string Password { get; set; }
	public bool VerifiedStatus { get; set; }
	public DateTime CreationTime { get; set; }
}
void Main()
{
	//and then you can just ...
	string myJsonString = "...";
	Config config = JsonConvert.DeserializeObject<Config>(myJsonString);
}
