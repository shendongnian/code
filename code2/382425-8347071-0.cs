    public interface IServiceModelBase<out TRootNode> 
         where TRootNode : ServiceNodeVMBase 
    { 
        TRootNode RootNode { get; }     
    } 
    public abstract class ServiceModelBase<TRootNode> : IServiceModelBase<TRootNode>
    {
        ...
    }
    public class ServiceModelLoadedEventArgs : EventArgs   
    {   
      public IServiceModelBase<ServiceNodeVMBase> ServiceModel { get; set; }  
      ...   
    }   
    public class ServiceModelEditor : ServiceModelBase<ServiceNodeVMEditor>  
