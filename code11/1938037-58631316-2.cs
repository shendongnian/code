C#
var inputs = new Dictionary<string, string>
{
    { "name", "John" },
    { "address", "NA" }
};
var strings = new[]{
    "xyz.com/zexample/set(person='{inputs[\"name\"]})",
    "xy.co/set(person='{inputs[\"name\"]},foo='{inputs[\"address\"]}')"
};
Regex re = new Regex(@"\{inputs\[""(?<key>[a-z]+)""\]\}", RegexOptions.IgnoreCase);
var results = new List<String>();
//  This will throw System.Collections.Generic.KeyNotFoundException if the key is not 
//  found in inputs. 
//  If this local function doesn't compile, let me know, and I'll translate it into 
//  an earlier version of C#. 
string MatchLookup(string key) => inputs[key];
foreach (var input in strings)
{
    results.Add(re.Replace(input, m => MatchLookup(m.Groups["key"].Value)));
}
