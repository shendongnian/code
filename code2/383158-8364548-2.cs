    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    namespace MenuTreeDemo
    {
    	public class MenuNode
    	{
    		public int Id { get; set; }
    		public int ParentId { get; set; }
    		public string Description { get; set; }
    		public string Url { get; set; }
    		public List<MenuNode> Children { get; set; }
    		
    		
    		public MenuNode ()
    		{
    			Children = new List<MenuNode>();
    		}
    		
    		
    		// Will visit all descendants and turn them into menu items.
    		public MenuItem ToMenuItem()
    		{
    			MenuItem item = new MenuItem(Description) { NavigateUrl=Url };
    			foreach (MenuNode child in Children)
    			{
    				item.ChildItems.Add(child.ToMenuItem());
    			}
    			
    			return item;
    		}
    	}
    }
