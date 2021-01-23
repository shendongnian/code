    using System;
    using System.Web;
    using System.Runtime.Serialization;
    
    // "" needed to clear out ugly xmlns namespace tags to make it plain old XML (POX)
    // If you want them, ether take it out or specify on your own
    [DataContract(Name = "TestInput", Namespace = "")] 
    public class TestInput
    {
        // NOTE: If Order property is skipped, the data will be serialized 
        // alphabetically per variable names!!
        // This can kill services, so better to be explicit
        [DataMember(Order = 0)] 
        int SomeNumber;
    
        // NOTE: If Name property is used XML will have UserName instead of internalUserName
        [DataMember(Name="UserName", Order = 1)] 
        string internalUserName;       
    }
