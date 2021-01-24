    public class Output
    {
        [XmlElementAttribute("ResponseLineTest")]
        public OrderLn[] ResponseLine { get; set; }
    }
    public class OrderLn
    {
        public string Order { get; set; }
    }
    [ServiceContract(Namespace = "Question59659046")]
    [XmlSerializerFormat]
    public interface IQuestion59659046Service
    {
        [OperationContract]
        Output GetOutput(string input);
    }
