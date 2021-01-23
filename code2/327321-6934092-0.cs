    [DataContract(Name = "FaceList")
    public class FaceList
    {
    ...
    [DataMember(Name = "Result")]
    List<Face> Faces { get; set; }
    ...
    }
