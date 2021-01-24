public class Label
{
    public string en { get; set; }
}
public class Setting
{
    public string type { get; set; }
    public string id { get; set; }
    public Label label { get; set; }
}
public class RootObject
{
    public object name { get; set; }
    public string flag { get; set; }
    public List<Setting> settings { get; set; }
}
