    void Main()
    {
    	var b = new Bag<string>();
    	b.Add("bike");
    	b.Add("erasmus");
    	b.Add("kumquat");
    	b.Add("beaver");
    	b.Add("racecar");
    	b.Add("barnacle");
    	
    	foreach (var thing in b)
    	{
    		Console.WriteLine(thing);
    	}
    }
    
    // Define other methods and classes here
    
    public class Bag<T> : IEnumerable<T>
    {
    	public Node<T> first;// first node in list
    
    	public class Node<T>
    	{
    		public T item;
    		public Node<T> next;
    
    		public Node(T item)
    		{
    			this.item = item;
    		}
    	}
    
    
    	public void Add(T item)
    	{
    		Node<T> oldFirst = first;
    		first = new Node<T>(item);
    		first.next = oldFirst;
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return GetEnumerator();
    	}
    
    	public IEnumerator<T> GetEnumerator()
    	{
    		return new BagEnumerator<T>(this);
    	}
    
    	public class BagEnumerator<V> : IEnumerator<T>
    	{
    		private Node<T> _head;
    		private Bag<T> _bag;
    		private Node<T> _curNode;
    
    
    		public BagEnumerator(Bag<T> bag)
    		{
    
    			_bag = bag;
    			_head = bag.first;
    			_curNode = default(Node<T>);
    
    		}
    
    		public T Current
    		{
    			get { return _curNode.item; }
    		}
    
    
    		object IEnumerator.Current
    		{
    			get { return Current; }
    		}
    
    		public bool MoveNext()
    		{
    			if (_curNode == null)
    			{
    				_curNode = _head;
    				if (_curNode == null)
    				return false;
    				return true;
    			}
    			if (_curNode.next == null)
    			return false;
    			else
    			{
    				_curNode = _curNode.next;
    				return true;
    			}
    
    		}
    
    		public void Reset()
    		{
    			_curNode = default(Node<T>); ;
    		}
    
    
    		public void Dispose()
    		{
    		}
    	}
    }
