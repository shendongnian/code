    [System.ComponentModel.DefaultValueAttribute ("0")]
    [XmlElement(ElementName = "Salary" , typeof(double))]
    public string Salary { get; set; }
    
    [System.ComponentModel.DefaultValueAttribute ("02-May-2011")]
    [XmlElement(ElementName = "BirthDate" , typeof(datetime))]
    public string Phone { get; set; }
Another option is to use a special pattern to create a Boolean field recognized by the XmlSerializer, and to apply the XmlIgnoreAttribute to the field. The pattern is created in the form of propertyNameSpecified. For example, if there is a field named "MyFirstName" you would also create a field named "MyFirstNameSpecified" that instructs the XmlSerializer whether or not to generate the XML element named "MyFirstName".
