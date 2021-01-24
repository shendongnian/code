string json = @"{
  'Name': 'Bad Boys',
  'ReleaseDate': '1995-4-7T00:00:00',
  'Genres': [
    'Action',
    'Comedy'
  ]
}";
Movie m = JsonConvert.DeserializeObject<Movie>(json);
string name = m.Name;
// Bad Boys
With the new .NET Core JsonSerializer it would look something like the following.
string json = ... ;
var movie = System.Text.Json.JsonSerializer.Deserialize<Movie>(json);
string name = m.Name;
# I still want to use `Dictionary<string, object>`
Again, I don't know what `JSONApiCall` does to arrays and nested objects.
If you structure the code sligthly differently it could help you debug it easier. 
Consider the following snippet.
//Put a breakpoint here and examine the type of phones;
var phonesO = user["phones"];
var phones = phonesO as IEnumerable; // This may or may not work
if (enumerable == null)
{
   // Nope, something is not right
}
foreach (var phoneO in phones)
{
    //Put a breakpoint here and examine the type of `phoneO`
    var phone = phoneO as Dictionary<string, object>();
    {
        var number = phone["number"];
        var phoneId = phone["phone_id"];
    }
}
