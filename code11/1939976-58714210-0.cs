csharp
public static class LocalizedStrings
{
    public static readonly string STR_RELEASED = "STR_RELEASED";
    public static readonly string SHUT_DOWN_SYSTEM = "SHUT_DOWN_SYSTEM";
    public static readonly string VAC_MAINTAINED = "VAC_MAINTAINED";
}
public enum VaccumStatus
{
    [LocalizedDescription(LocalizedStrings.STR_RELEASED)]
    Released,
    [LocalizedDescription(LocalizedStrings.SHUT_DOWN_SYSTEM)]
    ShutDown,
    [LocalizedDescription(LocalizedStrings.VAC_MAINTAINED)]
    Maintained
}
public class LocalizedDescriptionAttribute : DescriptionAttribute
{
    readonly string _resourceKey;
    public LocalizedDescriptionAttribute(string resourceKey)
    {
        _resourceKey = resourceKey;
    }
    public override string Description
    {
        get
        {
            string description = LanguageStrings.ResourceManager.GetString(_resourceKey);
            return string.IsNullOrWhiteSpace(description) ? $"[[{_resourceKey}]]" : description;
        }
    }
}
