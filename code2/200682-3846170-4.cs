    {
        MyNode n = new MyNode();
        var c = new MyNode.MyContainer();
        c.AddChild(n);
        MySubNode s = new MySubNode();
        c.AddChild(s);
        OtherNode o = new OtherNode();
        o.AddChild(o);
        //compiler doesn't allow this, as you'd expect:
        //c.AddChild(o);
    }        
    public interface IContainer<TContainerType, TNodeType>
        where TNodeType : GenericNode<TContainerType, TNodeType>
        where TContainerType : TNodeType, IContainer<TContainerType, TNodeType>
    {
    }
    public static class ContainerExtensions
    {
        public static void AddChild<TContainerType, TNodeType>(this IContainer<TContainerType, TNodeType> self, TNodeType node)
            where TNodeType : GenericNode<TContainerType, TNodeType>
            where TContainerType : TNodeType, IContainer<TContainerType, TNodeType>
        {
            GenericNode<TContainerType, TNodeType>.AddChild(self as TContainerType, node);
        }
    }
    public class GenericNode<TContainerType, TNodeType>
        where TNodeType : GenericNode<TContainerType, TNodeType>
        where TContainerType : GenericNode<TContainerType, TNodeType>
    {
        TContainerType parent;
        TNodeType nextNode;
        TNodeType previousNode;
        // Only used by Container
        TNodeType firstChild;
        TNodeType secondChild;
        internal static void AddChild(TContainerType container, TNodeType node)
        {
            container.firstChild = node;
            node.parent = container;
        }
    }
    public class MyNode : GenericNode<MyContainer, MyNode>
    {        
    }
    public class MyContainer : MyNode, IContainer<MyContainer, MyNode>
    {
    }
    public class MySubNode : MyNode
    {
    }
    public class OtherNode : GenericNode<OtherNode, OtherNode>, IContainer<OtherNode, OtherNode>
    {
    }
