    public static void PopulateRows(TreeNodeCollection nodesCollection, DataTable rowsData) 
		{
			foreach (DataRow child in dataChildNode.Rows)
			{
				var thisNode = new TreeNode(frist["COMPONENT_NAME"].ToString());
				nodesCollection.Add(thisNode);
				var sqlCommand = new SqlCommand(Database_Query.Rest_of__Node_Query, Connection);
				sqlCommand.Parameters.AddWithValue("@Parentname", child["COMPONENT_NAME"].ToString());
				var dataChildNode = Table.dataTable_Create_Method(sqlCommand);
				PopulateRows(thisNode.Nodes, dataChildNode);
			}
		}
		public  Task Populate_Tree_View(TreeView treeView)
		{
			try
			{
				SqlCommand new1 = new SqlCommand(@"select COMPONENT_NAME from bom", Connection);
				var data = Table.dataTable_Create_Method(new1);
				while (true)
				{
					var SqlCommand = new SqlCommand(Database_Query.ParentNode_Query, Connection);
					var data_Parent = Table.dataTable_Create_Method(SqlCommand);
					PopulateRows(treeView.Nodes, data_Parent); 
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, MediaTypeNames.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return Task.CompletedTask;
		}
