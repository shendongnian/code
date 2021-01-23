    // This is the root of the address book data graph
    // but we want root written out using camel casing
    // so we use XmlRoot to instruct the XmlSerializer
    // to use the name 'addressBook' when reading/writing
    // the XML data
    [XmlRoot("addressBook")]
    public class AddressBook
    {
      // In this case a contact will represent the owner
      // of the address book. So we deciced to instruct
      // the serializer to write the contact details out
      // as <owner>
      [XmlElement("owner")]
      public Contact Owner;
      // Here we apply XmlElement to an array which will
      // instruct the XmlSerializer to read/write the array
      // items as direct child elements of the addressBook
      // element. Each element will be in the form of 
      // <contact ... />
      [XmlElement("contact")]
      public Contact[] Contacts;
    }
    public class Contact
    {
      // Here we instruct the serializer to treat FirstName
      // as an xml element attribute rather than an element.
      // We also provide an alternate name for the attribute.
      [XmlAttribute("firstName")]
      public string FirstName;
      [XmlAttribute("lastName")]
      public string LastName;
      [XmlElement("tel1")]
      public string PhoneNumber;
      [XmlElement("email")]
      public string EmailAddress;
    }
