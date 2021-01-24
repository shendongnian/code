c#
public class BaseClass
{
    public List<ItemClass> ItemList { get; set; }
    public ListInfo ListInfo { get; set; }
}
and use `JsonConvert.DeserializeObject` to deserialize json to your class
c#
string json = "{\"itemList\":[{\"id\":1,\"name\":\"Item 1 Name\"},{\"id\":2,\"name\":\"Item 2 Name\"}],\"listInfo\":{\"info1\":1,\"info2\":\"bla\"}}";
var data =  JsonConvert.DeserializeObject<BaseClass>(json);
