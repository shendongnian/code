	using System;
	using System.Text;
	using System.Xml;
	using System.Drawing;
	using System.Windows.Forms;
	namespace TreeViewTest
	{
		class XmlTreeViewBuilder
		{
			private XmlDocument xDoc;
			private TreeView tView;
			//Constructor with parameters
			public XmlTreeViewBuilder(XmlDocument xDocument, TreeView treeView)
			{
				this.xDoc = xDocument;
				this.tView = treeView;
			}
			public void getTreeView()
			{
				tView.Nodes.Clear();                                        //Clear out the nodes before building
				XmlNode pNode = xDoc.DocumentElement;                       //Set the xml parent node = xml document element
				string Key = pNode.Name == null ? "" : pNode.Name;          //If null set to empty string, else set to name
				string Value = pNode.Value == null ? Key : pNode.Value;     //If null set to node name, else set to value
				TreeNode tNode = tView.Nodes.Add(Key, Value);               //Add the node to the Treeview, set tNode to that node
				AddTreeNodes(pNode, tNode);                                 //Call the recursive function to build the tree
			}
			//Build out the tree recursively
			private void AddTreeNodes(XmlNode currentParentNode, TreeNode currentTreeNode)
			{
				//Check to see if the node has attributes, if so add them
				if (currentParentNode.Attributes != null && currentParentNode.Attributes.Count > 0)
				{
					foreach (XmlAttribute attrib in currentParentNode.Attributes)
					{
						//Create a node for the attribute name
						TreeNode attribNode = new TreeNode();
						attribNode.Name = attrib.Name;
						attribNode.ForeColor = Color.Red;
						attribNode.Text = "<Attribute>:" + attrib.Name;
						//treeNode adds the attribute node
						currentTreeNode.Nodes.Add(attribNode);
						//Create a node for the attribute value
						TreeNode attribValue = new TreeNode();
						attribValue.Name = attrib.Name;
						attribValue.ForeColor = Color.Blue;
						attribValue.Text = attrib.Value;
						//Attribute node adds the value node
						attribNode.Nodes.Add(attribValue);
					}
				}
				//Recursively add children, grandchildren, etc...
				if (currentParentNode.HasChildNodes)
				{
					foreach (XmlNode childNode in currentParentNode.ChildNodes)
					{
						string Key = childNode.Name == null ? "" : childNode.Name;
						string Value = childNode.Value == null ? Key : childNode.Value;
						TreeNode treeNode = currentTreeNode.Nodes.Add(Key, Value);
						//Recursive call to repeat the process for all child nodes which may be parents
						AddTreeNodes(childNode, treeNode);
					}
				}
			}
		}
	}
