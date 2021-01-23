    [DataContract]
    public class DataObject
    {
    [DataMember(Name = "detections")]
    public List<List<Detection>> Detections { get; set; }
    }
