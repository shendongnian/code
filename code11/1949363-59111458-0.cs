csharp
bool allNamesEmpty = _Treasures.All(t => t.Name == string.Empty);
Side note; all of those properties can be rewritten as (simpler) auto-properties with initializers:
csharp
public class Item
{
    public string Name { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public int Time { get; set; } = 0;
}
