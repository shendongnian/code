    var xml = XElement.Parse(@"<testsystem>
        <test>
           <name>one</name>
        </test>
    </testsystem>
    ");
    
    string name = xml.Element("test").Element("name").Value;
