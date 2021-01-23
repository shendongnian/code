    public interface IDTO<Node> where Node : ServiceNodeBase
    {
        ServiceModelBase<Node> CreateBusinessObject();
    }
    public abstract class DTO_Base<Model,Node> : IDTO<Node>
        where Model : ServiceModelBase<Node>
        where Node : ServiceNodeBase
    {
        public abstract Model CreateBusinessObject();
        #region IDTO<Node> Members
        ServiceModelBase<Node> IDTO<Node>.CreateBusinessObject()
        {
            return CreateBusinessObject();
        }
        #endregion
    }
    public class DTO_Editor : DTO_Base<ServiceModelEditor, ServiceNodeEditor>
    {
        public override ServiceModelEditor CreateBusinessObject()
        {
            // the object to return have to be of type ServiceModelEditor
            // which is derived from ServiceModelBase<ServiceNodeEditor>
            // public class ServiceModelEditor : ServiceModelBase<ServiceNodeEditor>
            // ServiceNodeEditor is derived from ServiceNodeBase
            // public class ServiceNodeEditor : ServiceNodeBase
            ServiceModelEditor target = new ServiceModelEditor();
            return target;
            
        }
    }
