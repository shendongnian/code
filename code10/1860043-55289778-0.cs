public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        return value.GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            .GetName();
    }
}
where `.GetName()` will retrieve localized string from resources
Then you should call it:
<p>
    @String.Format("{0} {1} {2}", ((Title)Model.Person.Title).GetDisplayName(), Model.Person.FirstName, Model.Person.LastName)
</p>
