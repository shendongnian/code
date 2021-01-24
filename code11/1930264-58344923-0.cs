public IEnumerable<YourType> CatchDetailWrappers { get; set; }
public class YourType
{
    public string OtherProperty { get; set; }
    [...]
    public GuidLookupItem YourPropertyName { get; set; }
}
