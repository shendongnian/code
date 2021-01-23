    public static class TreeViewBuilder
    {
    	public static TreeView BuildTreeView( this TreeView tree )
    	{
    		DataTable projects = GetProjects();
    		DataTable releases = GetRealeases();
    		
    		return InternalTreeViewBuilder(tree, projects, releases);
    	}
    }
