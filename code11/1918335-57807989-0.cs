[DataContract(Name = "entity_update")]
public class EntityUpdate 
{
    private string _name;
    private bool _nameChanged;
    [DataMember(Name = "name")]
    public string Name { get => _name; set { _name = value; _nameChanged = true; } }
    [DataMember(Name = "description")]
    public string Description { get; set; }
}
