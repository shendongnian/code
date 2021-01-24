csharp
public class MyEntity : TableEntity
{
    public string MyPropery { get; set; }
    [IgnoreProperty]
    public string[] MyProperyArray
    {
        get
        {
            return JsonConvert.DeserializeObject<string[]>(MyPropery);
        }
        set
        {
            MyPropery = JsonConvert.SerializeObject(value);
        }
    }
}
