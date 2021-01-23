     [ServiceContract(
          Namespace="namespaceuri",
          Name="contractname")]
     public interface IInstallerBootstrapperService {
          [OperationContract(
                 Namespace="namespaceuri", 
                 Action ="actionuri", 
                 ReplyAction="replyactionuri")]
          void Download( string path);
     }
