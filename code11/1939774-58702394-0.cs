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
