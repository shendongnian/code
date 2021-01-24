    public interface IRootHierarchyBuilder 
    {
        IHierarchyBuilder AddRootNode(MyNode rootNode);
    }
    
    public interface IHierarchyBuilder
    {
        IHierarchyBuilder AddNode(MyNode childNode);
        MyNode Build();
    }
    
    public class HierarchyBuilder : IRootHierarchyBuilder, IHierarchyBuilder
    {
        private readonly IDictionary<int, MyNode> _nodes;
        private MyNode _rootNode;
        
        private HierarchyBuilder()
        {
            _nodes = new Dictionary<int, MyNode>();
        }
        
        public static IRootHierarchyBuilder Create()
        {
            return new HierarchyBuilder();
        }
        
        IHierarchyBuilder IRootHierarchyBuilder.AddRootNode(MyNode rootNode)
        {
            if (_rootNode != null)
            {
                throw new InvalidOperationException("Root node already exists.");
            }
            _rootNode = rootNode;
            _nodes[rootNode.Id] = rootNode;
            return this;
        }
        
        IHierarchyBuilder IHierarchyBuilder.AddNode(MyNode childNode)
        {
            if (_rootNode == null)
            {
                throw new InvalidOperationException("Root node not set.");
            }
            
            if (_nodes.ContainsKey(childNode.Id))
            {
                throw new Exception("This child has already been added.");
            }
            
            MyNode parentNode;
            if (!_nodes.TryGetValue(childNode.ParentId, out parentNode))
            {
                throw new KeyNotFoundException("Parent node not found.");
            }
            parentNode.Nodes.Add(childNode);
            
            _nodes[childNode.Id] = childNode;
            return this;
        }
        
        MyNode IHierarchyBuilder.Build()
        {
            if (_rootNode == null)
            {
                throw new InvalidOperationException("Root node not set.");
            }
            return _rootNode;            
        }
    }
	
