var dataLines = File.ReadAllLines(filePath);
var userPassDictionary = dataLines.Skip(1)
                                  .Select(x=> x.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries))
                                  .ToDictionary(x=> x.First().ToLower(),v=>v.Last());
Now you could access validate the user as
if (userPassDictionary[txtUsnme.Text.ToLower()] == txtPass.Text)
{
}
