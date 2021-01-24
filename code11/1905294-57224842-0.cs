    [XmlRoot(ElementName = "AccessControlList", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/", IsNullable = true)]
    public class AccessControlList
    {
        [XmlElement(ElementName = "Grant", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/", IsNullable = true)]
        public List<CanonicalUser> Grant { get; set; }
    }
    [XmlRoot(ElementName = "Grant", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/", IsNullable = true)]
    public class CanonicalUser
    {
        [XmlElement(ElementName = "Grantee", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/", IsNullable = true)]
        public Grantee Grantee { get; set; }
        [XmlElement(ElementName = "Permission", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/", IsNullable = true)]
        public string Permission { get; set; }
    }
