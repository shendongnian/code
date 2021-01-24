    [ServiceContract]
       public interface IStorageBackendSvc {
          ...
          [OperationContract]
          [FaultContract(typeof(DescriptiveFault))]
          Task AcceptWmaMediaType(int stationId, OpaqueMediaType mediaType);
    
       }
