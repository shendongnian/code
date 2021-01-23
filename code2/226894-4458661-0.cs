List<string> seen = new List<string>();
while ((line = file.ReadLine()) != null)
{
foreach (Match match in Regex.Matches(line, @"(\w*)\.\."))
{
  foreach(Group g in match.Groups) 
  {
    if(!seen.Contains(g.Value)
    {
      seen.Add(g.Value);
      dest.WriteLine(g.Value);
    }
}
counter++;
}
