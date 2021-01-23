    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyNode rootNode = new MyNode { Code = "abc", Description = "abc node" };
                var tree = new IndexedTree<MyNode, string>("Code", rootNode);
                tree.Root.AddChild(new MyNode { Code = "def", Description = "def node" });
                MyNode foundNode = tree.FindNode("abc");
                if (foundNode != null)
                {
                    Console.WriteLine("Found node: " + foundNode.Description);
                    Console.WriteLine("with children:");
                    foreach (MyNode child in foundNode.Children)
                    {
                        Console.WriteLine("  " + child.Description);
                    }
                }
                foundNode = tree.FindNode("def");
                Console.ReadLine();
            }
        }
        public class NodeEventArgs : EventArgs
        {
            public TreeNodeBase Node { get; private set; }
            public bool Cancel { get; set; }
            public NodeEventArgs(TreeNodeBase node)
            {
                this.Node = node;
            }
        }
        public abstract class TreeNodeBase
        {
            public ReadOnlyCollection<TreeNodeBase> Children
            {
                get { return new ReadOnlyCollection<TreeNodeBase>(this.children); }
            }
            private IList<TreeNodeBase> children;
            public TreeNodeBase()
                : this(new List<TreeNodeBase>())
            {
            }
            public TreeNodeBase(IList<TreeNodeBase> children)
            {
                if (children == null)
                {
                    throw new ArgumentNullException("children");
                }
                this.children = children;
            }
            public event EventHandler<NodeEventArgs> ChildAdding;
            public event EventHandler<NodeEventArgs> ChildRemoving;
            protected virtual void OnChildAdding(NodeEventArgs e)
            {
                if (this.ChildAdding != null)
                {
                    this.ChildAdding(this, e);
                }
            }
            protected virtual void OnChildRemoving(NodeEventArgs e)
            {
                if (this.ChildRemoving != null)
                {
                    this.ChildRemoving(this, e);
                }
            }
            public TreeNodeBase AddChild(TreeNodeBase child)
            {
                NodeEventArgs eventArgs = new NodeEventArgs(child);
                this.OnChildAdding(eventArgs);
                if (eventArgs.Cancel)
                {
                    return null;
                }
                this.children.Add(child);
                return child;
            }
            public void RemoveChild(TreeNodeBase child)
            {
                NodeEventArgs eventArgs = new NodeEventArgs(child);
                this.OnChildRemoving(eventArgs);
                if (eventArgs.Cancel)
                {
                    return;
                }
                this.children.Remove(child);
            }
        }
        public class MyNode : TreeNodeBase
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }
        public class IndexedTree<TNode, TIndexKey> where TNode : TreeNodeBase, new()
        {
            public TNode Root { get; private set; }
            public Dictionary<TIndexKey, TreeNodeBase> Index { get; private set; }
            public string IndexProperty { get; private set; }
            public IndexedTree(string indexProperty, TNode rootNode)
            {
                if (String.IsNullOrEmpty(indexProperty))
                {
                    throw new ArgumentNullException("indexProperty");
                }
                Type nodeType = rootNode.GetType();
                PropertyInfo property = nodeType.GetProperty(indexProperty);
                if (property == null)
                {
                    throw new ArgumentException("The [" + indexProperty + "] property does not exist in [" + nodeType.FullName + "].", "indexProperty");
                }
                this.IndexProperty = indexProperty;
                this.Index = new Dictionary<TIndexKey, TreeNodeBase>();
                this.Root = rootNode;
                this.ChildAdding(this, new NodeEventArgs(Root));
            }
            public TNode FindNode(TIndexKey key)
            {
                if (Index.ContainsKey(key))
                {
                    return (TNode)Index[key];
                }
                return null;
            }
            private void ChildAdding(object sender, NodeEventArgs e)
            {
                if (e.Node.Children.Count > 0)
                {
                    throw new InvalidOperationException("You can only add nodes that don't have children");
                    // Alternatively, you could recursively get the children, set up the added/removed events and add to the index
                }
                e.Node.ChildAdding += new EventHandler<NodeEventArgs>(ChildAdding);
                e.Node.ChildRemoving += new EventHandler<NodeEventArgs>(ChildRemoving);
                Index.Add(this.GetNodeIndex(e.Node), e.Node);
            }
            private void ChildRemoving(object sender, NodeEventArgs e)
            {
                if (e.Node.Children.Count > 0)
                {
                    throw new InvalidOperationException("You can only remove leaf nodes that don't have children");
                    // Alternatively, you could recursively get the children and remove from the index
                }
                Index.Remove(this.GetNodeIndex(e.Node));
            }
            private TIndexKey GetNodeIndex(TreeNodeBase node)
            {
                TIndexKey key = (TIndexKey)node.GetType().GetProperty(this.IndexProperty).GetValue(node, null);
                if (key == null)
                {
                    throw new ArgumentNullException("The node index property [" + this.IndexProperty + "] cannot be null", this.IndexProperty);
                }
                return key;
            }
        }
    }
