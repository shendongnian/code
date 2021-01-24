    // Deserialize your XML into an object variable called xmlObject, this assumes the XmlObject class is defined and the xmlObject is declared somewhere in scope
    
    Object something = null;
    
    if (xmlObject.ObjClass == "SomeClass")
    {
        something = new SomeClass();  // Assumes SomeClass is defined somewhere in scope
    }
    else
    {
        something = new OtherClass();  // Assumes OtherClass is defined somewhere in scope
    }
