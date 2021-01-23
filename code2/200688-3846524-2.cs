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
				c.firstChild = n; // not a real implementation ;)
				n.parent = c;
			}
		}
	}
	// EDIT: This does not work correctly! (see example below)
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
	public class MySubNode : MyNode
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
			MySubNode s = new MySubNode();
			//
			// This does not work because it tries to fill the generic in the
			// extension method with <MySubNode, MyContainer>, which does not
			// fulfil the constraint "where Container : Node".
			//
			//c.AddChild(s);
			OtherNode o = new OtherNode();
			o.AddChild(o);
		}
	}
