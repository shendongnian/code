    using System.Xml;        // for XmlTextReader and XmlValidatingReader
    using System.Xml.Schema; // for XmlSchemaCollection (which is used later)
    private static bool isValid = true;      // If a validation error occurs,
                                             // set this flag to false in the
                                             // validation event handler. 
    XmlTextReader r = new XmlTextReader("<path to XML document>");
    XmlValidatingReader v = new XmlValidatingReader(r);
    v.ValidationType = ValidationType.Schema;
    v.ValidationEventHandler += new ValidationEventHandler(MyValidationEventHandler); 
    while (v.Read())
    {   
        // Can add code here to process the content.
    }
    v.Close();
    // Check whether the document is valid or invalid.
    if (isValid)
        Console.WriteLine("Document is valid");
    else
        Console.WriteLine("Document is invalid");
    public static void MyValidationEventHandler(object sender, 
                                            ValidationEventArgs args) 
    {
        isValid = false;
        Console.WriteLine("Validation event\n" + args.Message);
    }
