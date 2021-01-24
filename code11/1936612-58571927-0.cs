C#
long numberOfLines = File.ReadLines(fileName).Count();
var projects = new Dictionary<string, Project>();
for (int i = 2; i <= numberOfLines; i += 2) 
{
    projects.Add("project " + i, new Project());
}
Cheers,
