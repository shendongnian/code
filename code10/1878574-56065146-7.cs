	public class Node
	{
		public uint NodeId { get; set; }
		public string DisplayName { get; set; }
		public bool ChildrenLoaded { get; set; }
		public ObservableCollection<Node> Children { get; set; }
		public Node()
		{
			ChildrenLoaded = false;
			Children = new ObservableCollection<Node>();
		}
		public void LoadChildNodes()
		{
			if (ChildrenLoaded) return;
            // e.g. Every SubCategory with a parentId of this NodeId
			var newChildren = whereverYourDataComesFrom.LoadChildNodes(NodeId);
			Children.Clear();
			foreach (Node child in newChildren)
				Children.Add(child);
			ChildrenLoaded = true;
		}
	}
