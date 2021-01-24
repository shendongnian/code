"abc".EndsWith("");
Returns true.
You'll have to clean up the list of suffixes, eg with :
myList=myList.Where(x=>!String.IsNullOrWhitespace(x)).ToList();
You can speed up and simplify your code if you use a regular expression stored in a static field to remove non-numeric characters, eg :
static Regex _cleanup;
static List<string> _suffixes;
static void Initialize(string sourcePath)
{
    _cleanup  = new Regex("\\D");
    _suffixes = File.ReadLines(sourcePath)
                    .Where(x=>!String.IsNullOrWhitespace(x))
                    .ToList();
}
public string CheckPhone(string phone)
{
    var cleanedphone = _cleanup.Replace(phone,"");
    var result = _suffixes.Any(a => cleanedphone.EndsWith(a)) ? "Yes" : "No";
    return result;
}
`File.ReadLines` returns an `IEnumerable<string>` instead of `string[]` which means you don't have to load the entire file before cleaning up the entries
