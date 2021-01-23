    @using System.Web.Mvc;
    @functions{
    public static object ConditionalActionLink(object actionLink, ICollection<string> arrAuthUsers)
    {
        bool objIsVisible = arrAuthUsers
            .Select(s => User.IsInRole(s))
            .Where(s => s.Equals(true))
            .Any();
        return (objIsVisible)
            ? actionLink
            : MvcHtmlString.Empty;
    }
