    	public class MyXmlSiteMapProvider : XmlSiteMapProvider
    	{
    		public override SiteMapNode FindSiteMapNode(string rawUrl)
    		{
    			SiteMapNode node = base.FindSiteMapNode(rawUrl);
    			if (node != null)
    			{
    				var page = HttpContext.Current.Handler as Page;
    				if (page != null)
    				{
    					page.Title = node.Title;
    				}
    				var newNode = node.Clone(true);
    				newNode.Url = rawUrl;
    				return newNode;
    			}
    			else
    			{
    				return null;
    			}
    		}
    
    		public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
    		{
    			if (node.Roles.OfType<string>().Any(r => String.Equals(r, "*", StringComparison.Ordinal) || context.User.IsInRole(r)))
    			{
    				return true;
    			}
    			else
    			{
    				throw new InsufficientRightsException();
    			}
    		}
    	}
