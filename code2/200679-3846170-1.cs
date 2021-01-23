	{
		MyNode n = new MyNode();
		MyContainer c = new MyContainer();
		c.AddChild(n);
		OtherNode o = new OtherNode();
		o.AddChild(o);
	}
	public abstract class Node<TNode>
		where TNode : Node<TNode>
	{
		Container parent;
		Node<TNode> nextNode;
		Node<TNode> previousNode;
		public class Container : Node<TNode>
		{
			Node<TNode> firstChild;
			Node<TNode> lastChild;
			public void AddChild(Node<TNode> n)
			{
				firstChild = n;
				n.parent = this;
			}
		}
	}
	public class MyNode : Node<MyNode>
	{
	}
	public class MyContainer : MyNode.Container
	{
	}
	public class OtherNode : Node<OtherNode>.Container
	{
	}
