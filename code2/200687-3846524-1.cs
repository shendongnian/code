	public abstract class GenericNode<Node, Container>
		where Node : GenericNode<Node, Container>
		where Container : Node
	{
		Container parent;
		Node nextNode;
		Node previousNode;
		// Only used by Container
		Node firstChild;
		Node secondChild;
		public static class ContainerHelpers
		{
			public static void AddChild(Container c, Node n)
			{
				c.firstChild = n; // this is obviously not a real function
				n.parent = c;
			}
		}
	}
	public static class GenericNodeExtensionMethods
	{
		public static void AddChild<Node, Container>(this Container c, Node n)
			where Node : GenericNode<Node, Container>
			where Container : Node
		{
			GenericNode<Node, Container>.ContainerHelpers.AddChild(c, n);
		}
	}
	//
	// Example Usage
	//
	public class MyNode : GenericNode<MyNode, MyContainer>
	{
	}
	public class MyContainer : MyNode
	{
	}
	public class OtherNode : GenericNode<OtherNode, OtherNode>
	{
	}
	class Program
	{
		static void Main(string[] args)
		{
			MyNode n = new MyNode();
			MyContainer c = new MyContainer();
			c.AddChild(n);
			OtherNode o = new OtherNode();
			o.AddChild(o);
		}
	}
