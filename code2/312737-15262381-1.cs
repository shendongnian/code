    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="AnotherObjectCollection", Namespace="http://schemas.datacontract.org/2004/07/SampleObject", ItemName="AnotherObject")]
    [System.SerializableAttribute()]
    public class AnotherObjectCollection : System.Collections.Generic.List<AnotherObject> {}
    
     DataContract(IsReference = true)]
        public class SampleObject
        {
          [DataMember]
          public long ID { get; private set; }
        
          [DataMember]
          public AnotherObjectCollection Objects { get; set; }
        }
