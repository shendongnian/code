csharp
public class Project
{
    public int id { get; set; }
    public string gid { get; set; }
    public string name { get; set; }
    public string resource_type { get; set; }
}
public class RootObject
{
    public List<Project> data { get; set; }
}
Then for parsing your code also changes:
csharp
var JSONObj = JsonConvert.DeserializeObject<RootObject>(response);
