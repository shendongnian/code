    [ServiceContract(Namespace="")]
    public interface IService1
    {
        [OperationContract]
        MyClass GetParameters();
        // TODO: Add your service operations here
    }
    [DataContract(Namespace="")]
    public class Parameter
    {
        [DataMember]
        public string ValueName
        {
            get;
            set;
        }
        [DataMember]
        public int Value
        {
            get;
            set;
        }
        public Parameter(string ValueName, int Value) 
        { 
            this.ValueName = ValueName; 
            this.Value = Value; 
        } 
    }
    [MessageContract(IsWrapped = false, WrapperNamespace="")]
    public class MyClass
    {
        [MessageBodyMember(Name = "MyClass", Namespace = "")]
        public List<Parameter> Parameters
        {
            get;
            set;
        }
    }
