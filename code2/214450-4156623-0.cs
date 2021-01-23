    public class TreeViewBuilder
    {
    	public static TreeView BuildTreeView( TreeView tree )
    	{
    		DataTable projects = GetProjects();
    		DataTable releases = GetRealeases();
    		
    		return InternalTreeViewBuilder(tree, projects, releases);
    	}
    }
