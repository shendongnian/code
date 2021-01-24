int partLength = 35;
string sentence = "Item 1 | Item 2 | Item 3 | Item 4 | Item 5 | Etc";
string[] words = sentence.Split(' ');
var parts = new Dictionary<int, string>();
string part = string.Empty;
int partCounter = 0;
for(int i = 0; i < words.Count(); i++)
{
    var newLength = part.Length + words[i].Length;
    if(words[i] == "|" && i + 1 < words.Count())
    {
        newLength += words[i + 1].Length;
    }
    if (newLength < partLength)
    {
        part += string.IsNullOrEmpty(part) ? words[i] : " " + words[i];
    }
    else
    {
        parts.Add(partCounter, part);
        part = words[i];
        partCounter++;
    }
}
parts.Add(partCounter, part);
foreach (var item in parts)
{
    Console.WriteLine(item.Value);
}
We still split on a space but we use a `for` loop to iterate through the strings. Before we check if the current word fits we need to check if it is a `|`. If it is then add the next word as well (if one exists). This should produce the output you are looking for.
