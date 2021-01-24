cs
if (de.Properties.ContainsKey("Name"))
{
    var name = de.Properties["Name"]?.ToString();
    if (string.IsNullOrEmpty(name))
    {
        name = "unknown";
    }
}
