    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Collections.Generic;
    
    namespace MenuTreeDemo
    {
    	public partial class Default : System.Web.UI.Page
    	{
    		protected void Page_Load(object sender, EventArgs e)	
    		{
    			if (!IsPostBack)
    			{
    				MenuNode root = ConvertTableToTree(GetTreeTable());
    				foreach (MenuNode topLevelNode in root.Children)
    				{
    					MyMenu.Items.Add(topLevelNode.ToMenuItem()); // Visits all nodes in the tree.
    				}
    			}
    		}
    		
    		
    		// The menu tree as an adjacency list in a table. 
    	    static DataTable GetTreeTable()
    	    {
    			DataTable table = new DataTable();
    			table.Columns.Add("Id", typeof(int));
    			table.Columns.Add("Description", typeof(string));
    			table.Columns.Add("Url", typeof(string));
    			table.Columns.Add("ParentId", typeof(int));
    		
    			table.Rows.Add(1, "TopMenu1", "/foo.html", 0);
    			table.Rows.Add(2, "SubMenu1.1", "/baz.html", 1);
    			table.Rows.Add(3, "SubMenu1.2", "/barry.html", 1);
    			table.Rows.Add(4, "SubMenu1.2.1", "/skeet.html", 3);
    			table.Rows.Add(5, "TopMenu2", "/bar.html", 0);
    			table.Rows.Add(6, "TopMenu3", "/bar.html", 0);
    			table.Rows.Add(7, "SubMenu3.1", "/ack.html", 6);
    			
    			return table;
    	    }
    	    
    	    
    		// See e.g. http://stackoverflow.com/questions/2654627/most-efficient-way-of-creating-tree-from-adjacency-list
    	    // Assuming table is ordered.
    	    static MenuNode ConvertTableToTree(DataTable table)
    		{
    			var map = new Dictionary<int, MenuNode>();
    			map[0] = new MenuNode() { Id = 0 }; // root node
    			
    			foreach (DataRow row in table.Rows)
    			{
    				int nodeId = int.Parse(row["Id"].ToString());
    				int parentId = int.Parse(row["ParentId"].ToString());
    				
    				MenuNode newNode = MenuNodeFromDataRow(row);
    				
    				map[parentId].Children.Add(newNode);
    				map[nodeId] = newNode;
    			}
    			
    			return map[0]; // root node
    		}
    		
    		
    		static MenuNode MenuNodeFromDataRow(DataRow row)
    		{
    			int nodeId = int.Parse(row["Id"].ToString());
    			int parentId = int.Parse(row["ParentId"].ToString());
    			string description = row["Description"].ToString();
    			string url = row["Url"].ToString();
    			
    			return new MenuNode() { Id=nodeId, ParentId=parentId, Description=description, Url=url };
    		}
    	}
    }
