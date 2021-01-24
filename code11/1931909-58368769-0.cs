c#
static HashSet<string> GenerateEdits(string word)
{
    // Normalize the case
    word = word.ToLower();
    var splits = new List<Tuple<string, string>>();
    for (int i = 0; i < word.Length; i++)
    {
        splits.Add(new Tuple<string, string>(word.Substring(0, i), word.Substring(i)));
    }
    var ret = new HashSet<string>();
    // All cases of one character removed
    foreach (var cur in splits)
    {
        if (cur.Item2.Length > 0)
        {
            ret.Add(cur.Item1 + cur.Item2.Substring(1));
        }
    }
    // All transposed possibilities
    foreach (var cur in splits)
    {
        if (cur.Item2.Length > 1)
        {
            ret.Add(cur.Item1 + cur.Item2[1] + cur.Item2[0] + cur.Item2.Substring(2));
        }
    }
    var letters = "abcdefghijklmnopqrstuvwxyz";
    // All replaced characters
    foreach (var cur in splits)
    {
        if (cur.Item2.Length > 0)
        {
            foreach (var letter in letters)
            {
                ret.Add(cur.Item1 + letter + cur.Item2.Substring(1));
            }
        }
    }
    // All inserted characters
    foreach (var cur in splits)
    {
        foreach (var letter in letters)
        {
            ret.Add(cur.Item1 + letter + cur.Item2);
        }
    }
    return ret;
}
And then exercise the code to see if a given user input can be easily convoluted to one of these entries.  Finding the best match can be done by weighted averages, or simply by presenting the list of possibilities to the user:
c#
// Example file from:
// https://raw.githubusercontent.com/smashew/NameDatabases/master/NamesDatabases/first%20names/all.txt
string source = @"all.txt";
var names = new HashSet<string>();
using (var sr = new StreamReader(source))
{
    string line;
    while ((line = sr.ReadLine()) != null)
    {
        names.Add(line.ToLower());
    }
}
var userEntry = "Giliam";
var found = false;
if (names.Contains(userEntry.ToLower()))
{
    Console.WriteLine("The entered value of " + userEntry + " looks good");
    found = true;
}
if (!found)
{
    // Try edits one edit away from the user entry
    foreach (var test in GenerateEdits(userEntry))
    {
        if (names.Contains(test))
        {
            Console.WriteLine(test + " is a possibility for " + userEntry);
            found = true;
        }
    }
}
if (!found)
{
    // Try edits two edits away from the user entry
    foreach (var test in GenerateEdits(userEntry))
    {
        foreach (var test2 in GenerateEdits(test))
        {
            if (names.Contains(test))
            {
                Console.WriteLine(test + " is a possibility for " + userEntry);
                found = true;
            }
        }
    }
}
>```none
>kiliam is a possibility for Giliam
>liliam is a possibility for Giliam
>viliam is a possibility for Giliam
>wiliam is a possibility for Giliam
