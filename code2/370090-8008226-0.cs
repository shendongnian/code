    public class ContainerEditor : ContainerBase
    {
      public NodeEditor Root {
        get { return (NodeEditor)base.Root; }
        set { base.Root = value; }
      }
      ...
    }
