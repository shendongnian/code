	private void SetSelected(XmlNode node)
	{
		Stack<XmlNode> path = new Stack<XmlNode>();
		XmlDataProvider dp = FindResource("xml") as XmlDataProvider;
		XmlNode root = dp.Document.LastChild;
		XmlNode n1 = node;
		//path.Push(node);
		while (n1.ParentNode != root)
		{
			n1 = n1.ParentNode;
			if (n1 == null)
				return;
			path.Push(n1);
		}
		path.Push(root);
		ItemsControl control = tree;
		foreach (XmlNode n in path)
		{
			
			TreeViewItem tviItem = control.ItemContainerGenerator.ContainerFromItem(n) as TreeViewItem;
			tviItem.IsExpanded = true;
			tviItem.UpdateLayout();
			control = tviItem;
		}
		TreeViewItem resultItem = control.ItemContainerGenerator.ContainerFromItem(node) as TreeViewItem;
		resultItem.IsSelected = true;
		resultItem.Focus();
	}
