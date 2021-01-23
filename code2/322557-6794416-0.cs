    using System.Xml.Linq;
        
    // Load the main and incremental xml files into XDocuments
    XDocument fullFile = XDocument.Load("fullfilename.xml");
    XDocument incrementalFile = XDocument.Load("incrementalfilename.xml");    
    
    // For each Person in the incremental file
    foreach (XElement person in incrementalFile.Element("Records").Elements("Person")) {
    
        // If the person should be added to the full file
        if (person.Attribute("recordaction").Value == "add") {
            fullFile.Element("Records").Add(person); // Add him
        }
    
        // Else the person already exists in the full file
        else {
            // Find the element of the Person to delete or change
            var personToChange =
                    (from p in fullFile.Element("Records").Elements("Person")
                        where p.Attribute("id").Value == person.Attribute("id").Value
                        select p).Single();
    
            // Perform the appropriate operation
            switch (person.Attribute("recordaction").Value) {
                case "chg":
                    personToChange = person;
                    break;
                case "del":
                    personToChange.Remove();
                    break;
                default:
                    throw new ApplicationException("Unrecognized attribute");
            }
        }
    }// end foreach
    
    // Save the changes to the full file
    fullFile.Save("fullfilename.xml");
     
