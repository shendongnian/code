    XmlNode firstName = document.SelectSingleNode("//ns:FirstName", namespaceManager);
    if (firstName == null)
    {
       Console.WriteLine("Could not find the node.");
    }
    else
    {
       Console.WriteLine("First Name is: {0}", firstName.InnerText);
    }
