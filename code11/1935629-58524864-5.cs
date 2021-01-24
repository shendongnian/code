CS
List<int> indexes = new List<int>();
for (int i = 0; i < items.Count; i++)
{
    string temp = items[i];
    while (temp.Length < match.Length && temp == match.Substring(0, temp.Length) && i < items.Count - 1)
    {
        indexes.Add(i + 1); // example was given using 1-based
        temp += items[++i];
    }
    if (temp == match)
    {
        indexes.Add(i + 1);
        break; // at this point, indexes contains the values sought
    }
    indexes.Clear();
}
With a list of 10,000 elements, where the elements to find are at the end, this runs in about 0.0003775 seconds.
