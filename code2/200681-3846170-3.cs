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
    public class TreeVariables<TContainerType, TNodeType>
    {
        public TContainerType Parent { get; set; }
        public TNodeType NextNode { get; set; }
        public TNodeType PreviousNode { get; set; }
        public TNodeType FirstChild { get; set; }
        public TNodeType SecondChild { get; set; }
    }
    public interface INode<TContainerType, TNodeType>
    {
        TreeVariables<TContainerType, TNodeType> TreeVars { get; }
    }
    public interface IContainer<TContainerType, TNodeType> : INode<TContainerType, TNodeType>
        where TNodeType : INode<TContainerType, TNodeType>
        where TContainerType : TNodeType, IContainer<TContainerType, TNodeType>
    {
    }
    public static class ContainerExtensions
    {
        public static void AddChild<TContainerType, TNodeType>(this IContainer<TContainerType, TNodeType> self, TNodeType child)
            where TNodeType: INode<TContainerType, TNodeType>
            where TContainerType : TNodeType, IContainer<TContainerType, TNodeType>
        {
            self.TreeVars.FirstChild = child;
            child.TreeVars.Parent = (TContainerType)self;
        }
    }
    public class MyNode : INode<MyNode.MyContainer, MyNode>
    {
        TreeVariables<MyNode.MyContainer, MyNode> treeVars = new TreeVariables<MyContainer,MyNode>();
        TreeVariables<MyNode.MyContainer, MyNode> INode<MyNode.MyContainer, MyNode>.TreeVars
        {
            get { return treeVars; }
        }
        public class MyContainer : MyNode, IContainer<MyContainer, MyNode>
        {
            TreeVariables<MyContainer, MyNode> INode<MyContainer, MyNode>.TreeVars
            {
                get { return treeVars; }
            }
        }        
    }
    
    public class MySubNode : MyNode
    {
    }
    public class OtherNode : INode<OtherNode, OtherNode>, IContainer<OtherNode, OtherNode>
    {
        TreeVariables<OtherNode, OtherNode> treeVars = new TreeVariables<OtherNode,OtherNode>();
        TreeVariables<OtherNode, OtherNode> INode<OtherNode, OtherNode>.TreeVars
        {
            get { return treeVars; }
        }
    }
