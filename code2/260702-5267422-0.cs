    public class NodeBase<T, TNode> :
        where T : ObjectBase
        where TNode : NodeBase<T, TNode>
    { 
        private ContainerBase<TNode, T> container;
        
        protected NodeBase(ContainerBase<TNode, T> owner)
        {  container = owner; }
    }
    public class ContainerBase<NodeType, ObjectType> :
        where NodeType : NodeBase<ObjectType, NodeType>
        where ObjectType : ObjectBase
    {
        public NodeType GetItem() { ... }
    }
    public class NodeNormal : NodeBase<ObjectNormal, NodeNormal>
    {
        public NodeNormal(ContainerNormal owner) :
            base(owner) { }
    }
    public class ContainerNormal : 
        ContainerBase<NodeNormal, ObjectNormal>
    { 
        //GetItem would return NodeNormal here
    }
