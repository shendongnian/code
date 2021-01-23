[ServiceContract]
public interface ISourceData
{    
[OperationContract]
MyClass GetClassData();
}
[DataContract]
public class MyClass 
{
    [DataMember]
    public string MyMember1 {get; set;}  // included in transport
    public int MyMember2 {get; set;}  // not included
}
