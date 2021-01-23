	public class MyNode
	{
		...
	}
	public class MyDataStructure
	{
		private HashSet<MyNode> nodes = new HashSet<MyNode>();
		/// <summary>
		/// Inserts an element to this data structure. 
		/// If the element already exists, returns false.
		/// Complexity is averaged O(1).
		/// </summary>
		public bool Add(MyNode node)
		{
			return node != null && this.nodes.Add(node);
		}
		/// <summary>
		/// Removes a random element from the data structure.
		/// Returns the element if an element was found.
		/// Returns null if the data structure is empty.
		/// Complexity is averaged O(1).
		/// </summary>
		public MyNode Pop()
		{
			// This loop can execute 1 or 0 times.
			foreach (MyNode node in nodes)
			{
				this.nodes.Remove(node);
				return node;
			}
			return null;
		}
	}
