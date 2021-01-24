    XNamespace Namespace = "http://mynamespace";
    string defaultXml = "<ReferResult><Text> Testing Referred</Text></ReferResult>";
    
    XElement myXml = XElement.Parse(defaultXml);
    myXml.Name = Namespace + myXml.Name.ToString();
    
    //If you want the children to have the same namespace, use the following.
    //If you want only the parent to have the namespace, omit the code bellow 
    foreach(var element in myXml.Descendants()){
    	element.Name = Namespace + element.Name.ToString();
    }
    //Output:
    //<ReferResult xmlns="http://mynamespace">
    //    <Text> Testing Referred</Text>
    //</ReferResult>
