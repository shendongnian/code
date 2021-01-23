    class TreeNode
	{
		public int Index {get;set;}
		public string Label {get;set;}
		
		public string Name 
		{
			get { return Index == 0 ? Label : Label + Index; }
		}
	}
 
