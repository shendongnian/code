    public abstract class ContainerBase<T> where T:NodeBase
    {
      T Root { get; set; }
      ...
    }
    
    public class ContainerEditor : ContainerBase<NodeEditor>
    {      
      ...
    }
