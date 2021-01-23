    class Customer {
    
            public Customer(XmlNode sourceNode) {
    
                // loop over attributes to get the simple stuff out
                foreach (XmlAttribute att in sourceNode.Attributes) {
                    // assign simpel stuff
                }
    
                // loop over child nodes and extract info
                foreach (XmlNode childNode in sourceNode.ChildNodes) {
                    switch (childNode.Name) {
                        case "PostalAddress": // here we find an address, so handle that
                            var adr = new PostalAddress(childNode);
                            switch (adr.AddressUsage) { // now find out what address we just got and assign appropriately
                                case "HomeAddress": this.HomeAddress = adr; break;
                                case "InvoiceAddress": this.InvoiceAddress = adr; break;
                                default: throw new Exception("Unknown address usage");
                            }    
                            break;
                        // other stuff like phone numbers can be handeled the same way
                        default: break;
                    }
                }
            }
    
            PostalAddress HomeAddress { get; private set; }
            PostalAddress InvoiceAddress { get; private set; }
            Name Name { get; private set; }
        }
    
        class PostalAddress {
            public PostalAddress(XmlNode sourceNode) {
                foreach (XmlAttribute att in sourceNode.Attributes) {
                    switch (att.Name) {
                       case "AddressUsage": this.AddressUsage = att.Value; break;
                       // other properties go here...
                }
            }
        }
            public string AddressUsage { get; set; }
    
        }
    
        class Name {
            public string First { get; set; }
            public string Middle { get; set; }
            public string Last { get; set; }
        }
