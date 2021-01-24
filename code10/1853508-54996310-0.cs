    public class ClassInner
    {
        // This is ignored because no [DataContract] was found
        [DataMember(Name = "nonexistentProperty")] 
        // This will still be set unobfuscated because the property name matches
        public string stringProperty2 { get; set; }
    }
