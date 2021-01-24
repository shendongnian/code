csharp
public class RolesInXmlFileSecurityTrimmingVisibilityProvider : SiteMapNodeVisibilityProviderBase
{
    public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
    {
        var isVisible = true;
        if (node.Attributes.ContainsKey("restrict-to-roles"))
        {
            var roles = Convert.ToString(node.Attributes["restrict-to-roles"]);
            if (!string.IsNullOrEmpty(roles))
            {
                 // Your implemenation may vary
                 isVisible = IsInRole(roles);
            }
        }
        return isVisible;
    }
}
Advantage:
This is very quick and you don't need to instantiate all the controllers to look for the `[Authorize]` attribute.
Drawback:
You have to manually maintain the `restric-to-roles` attributes in the MVC sitemap file on top of the MVC `[Authorize]` in the controllers.
