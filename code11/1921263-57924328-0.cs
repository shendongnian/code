``
public class MyObject
{
    public int id { get; set; }
    public string description { get; set; }
    public string name { get; set; }
    public string name_with_namespace { get; set; }
    public string path { get; set; }
    public string path_with_namespace { get; set; }
    public DateTime created_at { get; set; }
    public string default_branch { get; set; }
    public List<object> tag_list { get; set; }
    public string ssh_url_to_repo { get; set; }
    public string http_url_to_repo { get; set; }
    public string web_url { get; set; }
    public object readme_url { get; set; }
    public object avatar_url { get; set; }
    public int star_count { get; set; }
    public int forks_count { get; set; }
    public DateTime last_activity_at { get; set; }
    public Namespace @namespace { get; set; }
}
public class Namespace
{
    public int id { get; set; }
    public string name { get; set; }
    public string path { get; set; }
    public string kind { get; set; }
    public string full_path { get; set; }
    public object parent_id { get; set; }
}
``
Now, you can do this:
    var json1 = JsonConvert.DeserializeObject<MyObject>(json);
And then `json1` will be an object that was created from your json.  And from there, it's a snap to obtain the values you need.
**EDIT:**
I just realized your json is a list, and not a single item, so it would be:
    var json1 = JsonConvert.DeserializeObject<List<MyObject>>(json);
