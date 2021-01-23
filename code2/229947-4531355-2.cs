    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/getcar/{id}")]
        Car GetCar(string id);
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/updatecar/{id}")]
        Car UpdateCar(string id, Car car);
    }
    [DataContract]
    public class Car
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Make { get; set; }
    }
