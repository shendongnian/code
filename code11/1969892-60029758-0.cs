public class Item
{
    public string Id { get; set; }
    public string Value { get; set; }
}
public class Category
{
    public string GroupName { get; set; }
    public string GroupID { get; set; }
    public List<Item> Items { get; set; }
}
public class Status
{
    public string Message { get; set; }
    public bool DataFound { get; set; }
    public string TimeStamp { get; set; }
    public bool InternalError { get; set; }
}
public class API
{
    public List<Category> Category { get; set; }
    public Status Status { get; set; }
}
public class RootObject
{
    public API API { get; set; }
}
Above are the needed classes for succesful deserialization where RootObject class is the parent.
Use the following in your Main method.,
RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
List<Category> categories = root.API.Category;
