    public class ContainerBase<NodeType, ObjectType> : IContainerBase<NodeType, ObjectType>
        where NodeType : NodeBase<ObjectType> where ObjectType : ObjectBase {
    }
    
    public abstract class NodeBase<T> where T : ObjectBase {
        IContainerBase<NodeBase<T>, T> container;
        public NodeBase(IContainerBase<NodeBase<T>, T> owner) {
            container = owner;
        }
    }
    
    public class ContainerNormal : ContainerBase<NodeNormal, ObjectNormal> {
    }
    
    public interface IContainerBase<out NodeType, ObjectType>
        where NodeType : NodeBase<ObjectType> where ObjectType : ObjectBase {
    }
    
    public class NodeNormal : NodeBase<ObjectNormal> {
        //This doesn't work
        public NodeNormal(ContainerNormal owner) : base(owner) { }
    }
    
    public class ObjectNormal : ObjectBase {}
    
    public class ObjectBase{}
