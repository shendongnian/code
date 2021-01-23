    //Classes
    [DataContract]
    public class RootObject
    {
        [DataMember(Name = "data")]
        public DataObject Data { get; set; }
    }
    [DataContract]
    public class DataObject
    {
        [DataMember(Name = "detections")]
        public List<Detection> Detections { get; set; }
    }
    [DataContract]
    public class Detection
    {
        [DataMember(Name = "language")]
        public string Language { get; set; }
        [DataMember(Name = "isReliable")]
        public string IsReliable { get; set; }
        [DataMember(Name = "confidence")]
        public string Confidence { get; set; }
    }
    //Code to deserialize
    var serializer = new DataContractJsonSerializer(typeof(RootObject));
    var json = "{\"data\": {\"detections\": [{\"language\": \"tr\",\"isReliable\": false,\"confidence\": 0.086520955}]}}";
    var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
    var rootObject = serializer.ReadObject(stream);
    stream.Close();
