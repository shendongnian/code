    public class UnityComponent : IUnityComponent
    {
      public UnityComponent(IEnumerable<IMefComponent> mefComponents) 
      { 
        // mefComponents should be provided from your MEF container.
        MefComponents = mefComponents;
      }
      
      public IEnumerable<IMefComponent> MefComponents { get; private set; }
    }
