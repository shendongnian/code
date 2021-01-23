    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [ParseChildren(true)]
    [ToolboxData("<{0}:Menu runat=\"server\"></{0}:Menu>")]
    public class Menu : WebControl, INamingContainer
    {
    }
