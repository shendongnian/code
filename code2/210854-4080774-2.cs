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
                // Create the root node for the tree
                MyNode rootNode = new MyNode { Code = "abc", Description = "abc node" };
                // Instantiate a new tree with the given root node.  string is the index key type, "Code" is the index property name
                var tree = new IndexedTree<MyNode, string>("Code", rootNode);
                // Add a child to the root node
                tree.Root.AddChild(new MyNode { Code = "def", Description = "def node" });
                MyNode newNode = new MyNode { Code = "foo", Description = "foo node" };
                // Add a child to the first child of root
                tree.Root.Children[0].AddChild(newNode);
                // Add a child to the previously added node
                newNode.AddChild(new MyNode { Code = "bar", Description = "bar node" });
                // Show the full tree
                Console.WriteLine("Root node tree:");
                PrintNodeTree(tree.Root, 0);
                Console.WriteLine();
                // Find the second level node
                MyNode foundNode = tree.FindNode("def");
                if (foundNode != null)
                {
                    // Show the tree starting from the found node
                    Console.WriteLine("Found node tree:");
                    PrintNodeTree(foundNode, 0);
                }
                Console.ReadLine();
            }
            static void PrintNodeTree(MyNode node, int level)
            {
                Console.WriteLine(new String(' ', level * 2) + "[" + node.Code + "] " + node.Description);
                foreach (MyNode child in node.Children)
                {
                    // Recurse through each child
                    PrintNodeTree(child, ++level);
                }
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
        /// <summary>
        /// The base node class that handles the hierarchy
        /// </summary>
        public abstract class TreeNodeBase
        {
            /// <summary>
            /// A read-only list of children so that you are forced to use the proper methods
            /// </summary>
            public ReadOnlyCollection<TreeNodeBase> Children
            {
                get { return new ReadOnlyCollection<TreeNodeBase>(this.children); }
            }
            private IList<TreeNodeBase> children;
            /// <summary>
            /// Default constructor
            /// </summary>
            public TreeNodeBase()
                : this(new List<TreeNodeBase>())
            {
            }
            /// <summary>
            /// Constructor that populates children
            /// </summary>
            /// <param name="children">A list of children</param>
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
            /// <summary>
            /// Adds a child node to the current node
            /// </summary>
            /// <param name="child">The child to add.</param>
            /// <returns>The child node, if it was added.  Useful for chaining methods.</returns>
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
            /// <summary>
            /// Removes the specified child in the current node
            /// </summary>
            /// <param name="child">The child to remove.</param>
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
        /// <summary>
        /// Your custom node with custom properties.  The base node class handles the tree structure.
        /// </summary>
        public class MyNode : TreeNodeBase
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }
        /// <summary>
        /// The main tree class
        /// </summary>
        /// <typeparam name="TNode">The node type.</typeparam>
        /// <typeparam name="TIndexKey">The type of the index key.</typeparam>
        public class IndexedTree<TNode, TIndexKey> where TNode : TreeNodeBase, new()
        {
            public TNode Root { get; private set; }
            public Dictionary<TIndexKey, TreeNodeBase> Index { get; private set; }
            public string IndexProperty { get; private set; }
            public IndexedTree(string indexProperty, TNode rootNode)
            {
                // Make sure we have a valid indexProperty
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
                // Make sure we have a valid root node
                if (rootNode == null)
                {
                    throw new ArgumentNullException("rootNode");
                }
                // Set the index properties
                this.IndexProperty = indexProperty;
                this.Index = new Dictionary<TIndexKey, TreeNodeBase>();
                // Add the root node
                this.Root = rootNode;
                // Notify that we have added the root node
                this.ChildAdding(this, new NodeEventArgs(Root));
            }
            /// <summary>
            /// Find a node with the specified key value
            /// </summary>
            /// <param name="key">The node key value</param>
            /// <returns>A TNode if found, otherwise null</returns>
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
                // Add to the index.  Add events as soon as possible to be notified when children change.
                e.Node.ChildAdding += new EventHandler<NodeEventArgs>(ChildAdding);
                e.Node.ChildRemoving += new EventHandler<NodeEventArgs>(ChildRemoving);
                Index.Add(this.GetNodeIndex(e.Node), e.Node);
            }
            private void ChildRemoving(object sender, NodeEventArgs e)
            {
                if (e.Node.Children.Count > 0)
                {
                    throw new InvalidOperationException("You can only remove leaf nodes that don't have children");
                    // Alternatively, you could recursively get the children, remove the events and remove from the index
                }
                // Remove from the index.  Remove events in case user code keeps reference to this node and later adds/removes children
                e.Node.ChildAdding -= new EventHandler<NodeEventArgs>(ChildAdding);
                e.Node.ChildRemoving -= new EventHandler<NodeEventArgs>(ChildRemoving);
                Index.Remove(this.GetNodeIndex(e.Node));
            }
            /// <summary>
            /// Gets the index key value for the given node
            /// </summary>
            /// <param name="node">The node</param>
            /// <returns>The index key value</returns>
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
