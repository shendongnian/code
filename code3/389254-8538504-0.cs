    using System.Linq;
    using System.Xml.Linq; // requires a reference to System.Xml.Linq.dll
    
    // . . .
    
    // Load the XML (in this example, we use a file)
    XDocument document = XDocument.Load("yourfile.xml");
    
    // Initialize the namespace for the target element
    XNamespace coreNamespace = "urn:core";
    
    // Choose the first element below the root matching our target element
    // (or return null if there is none)
    XElement chosenElement = document.Root.Descendants(coreNamespace + "HB_Base").FirstOrDefault();
    
    string xmlString = null;
    if (chosenElement != null)
    {
        // We found it, now get the string representation of the XML
        xmlString = chosenElement.ToString();
    }
