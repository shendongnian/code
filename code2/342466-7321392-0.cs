    interface IPersonRoot
    {
        string Name { get; set; }
    }
    
    [XmlRootSerializer("Body")]
    interface IPersonCustomRoot
    {
        string Name { get; set; }
    }
    
    interface IPersonCustomAttribute
    {
        [XmlAttributeRuntimeSerializer("Id")]
        string Name { get; set; }
    }
    
