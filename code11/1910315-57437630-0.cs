string sentence = "We both arrived at the garage this morning";
string[] words = sentence.Split();
List<string> results = new List<string>();
string s = "";
foreach (string word in words)
{
    if (word.Contains("ar"))
    {
        if (s != "")
        {
            results.Add(s.Trim());
            s = "";
        }
        results.Add(word);
    }
    else
    {
        s += word + " ";
    }
}
if (s != "")
    results.Add(s);
// results contains the desired strings.
