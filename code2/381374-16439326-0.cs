     [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [FaultContract(typeof(ServiceData))]
        ForDataset GetCCDBdata();
        [OperationContract]
        [FaultContract(typeof(ServiceData))]
        string GetCCDBdataasXMLstring();
        //[OperationContract]
        //string GetData(int value);
        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);
        // TODO: Add your service operations here
    }
      [DataContract]
    public class ServiceData
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string ErrorDetails { get; set; }
    }
