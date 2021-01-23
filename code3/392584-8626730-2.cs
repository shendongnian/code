    [DataContract]
    public class SomeClass
    {
      [DataMember]
      public List<DataEvent> dataEvents { get; set; }
    }
    ...
    [ServiceContract]
    public interface IDataService
    {
      ...
      [OperationContract]
      [WebInvoke(UriTemplate = "SubmitDataEvents")]
      void SubmitDataEvents(SomeClass parameter);
    }
