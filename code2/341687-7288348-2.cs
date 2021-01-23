	public class Node
	{
		internal NodeTable pContainer;
		internal Node pTableNext;
		internal int pX;
		internal int pY;
		internal Node pLinkedListPrev;
		internal Node pLinkedListNext;
	}
	
	public class NodeTable :
		IEnumerable<Node>
	{
		private Node[] pTable;
		private Node pLinkedListFirst;
		private Node pLinkedListLast;
		
		// Capacity must be a prime number great enough as much items you want to store.
		// You can make this dynamic too but need some more work (rehashing and prime number computation).
		public NodeTable(int capacity)
		{
			this.pTable = new Node[capacity];
		}
		
		public int GetHashCode(int x, int y)
		{
			return (x + y * 104729); // Must be a prime number
		}
		
		public Node Get(int x, int y)
		{
			int bucket = (GetHashCode(x, y) & 0x7FFFFFFF) % this.pTable.Length;
			for (Node current = this.pTable[bucket]; current != null; current = current.pTableNext)
			{
				if (current.pX == x && current.pY == y)
					return current;
			}
			return null;
		}
	
		public IEnumerator<Node> GetEnumerator()
		{
			// Replace yield with a custom struct Enumerator to optimize performances.
			for (Node node = this.pLinkedListFirst, next; node != null; node = next)
			{
				next = node.pLinkedListNext;
				yield return node;
			}
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		
		public bool Set(int x, int y, Node node)
		{
			if (node == null || node.pContainer != null)
			{
				int bucket = (GetHashCode(x, y) & 0x7FFFFFFF) % this.pTable.Length;
				for (Node current = this.pTable[bucket], prev = null; current != null; current = current.pTableNext)
				{
					if (current.pX == x && current.pY == y)
					{
						this.fRemoveFromLinkedList(current);
						if (node == null)
						{
							// Remove from table linked list
							if (prev != null)
								prev.pTableNext = current.pTableNext;
							else
								this.pTable[bucket] = current.pTableNext;
							current.pTableNext = null;
						}
						else
						{
							// Replace old node from table linked list
							node.pTableNext = current.pTableNext;
							current.pTableNext = null;
							if (prev != null)
								prev.pTableNext = node;
							else
								this.pTable[bucket] = node;
							node.pContainer = this;
							node.pX = x;
							node.pY = y;
							this.fAddToLinkedList(node);
						}
						return true;
					}
					prev = current;
				}
				
				// New node.
				node.pContainer = this;
				node.pX = x;
				node.pY = y;
				// Add to table linked list
				node.pTableNext = this.pTable[bucket];
				this.pTable[bucket] = node;
				
				// Add to global linked list
				this.fAddToLinkedList(node);
				return true;
			}
			return false;
		}
		private void fRemoveFromLinkedList(Node node)
		{
			Node prev = node.pLinkedListPrev;
			Node next = node.pLinkedListNext;
			
			if (prev != null)
				prev.pLinkedListNext = next;
			else
				this.pLinkedListFirst = next;
			if (next != null)
				next.pLinkedListPrev = prev;
			else
				this.pLinkedListLast = prev;
				
			node.pLinkedListPrev = null;
			node.pLinkedListNext = null;
		}
		
		private void fAddToLinkedList(Node node)
		{
			node.pLinkedListPrev = this.pLinkedListLast;
			this.pLinkedListLast = node;
			if (this.pLinkedListFirst == null)
				this.pLinkedListFirst = node;
		}
	}
