List&lt;string&gt; seen = new List\&lt;string&gt;();
while ((line = file.ReadLine()) != null)
{
foreach (Match match in Regex.Matches(line, @"(\w*)\.\."))
{
    if(!seen.Contains(match.Groups[1])
    {
      seen.Add(match.Groups[1]);
      dest.WriteLine(match.Groups[1]);
    }
}
counter++;
}
