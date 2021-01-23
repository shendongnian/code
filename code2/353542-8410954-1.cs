    namespace anothertest
    {
        using System;
        using System.ServiceModel;
    
    
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IMyService")]
        public interface IMyService
        {
    
            [OperationContract]
            test.WebService.Entity.BusinessEntity[] GetAllActiveBusiness();
        }
        
     public class ProductClient : ClientBase<IMyService>, IMyService
            {
                #region Members
    
                public test.WebService.Entity.BusinessEntity[] GetAllActiveBusiness()
                {
                    return Channel.GetAllActiveBusiness();
                }
    
                #endregion
            }
    }
