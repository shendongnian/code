    var xml = @"<Contacts>
                    <Contact>
                    <Name>Example</Name>
                    <PhoneNo>0481-12345678</PhoneNo>
                    <SalesPhoneNo>310</SalesPhoneNo>
                    </Contact>
                </Contacts>";
    
    XDocument xDoc = XDocument.Parse(xml);
    // this will return 310
    string phoneNo = '0481-12345678';
    var salesPhoneNo = xDoc.XPathEvaluate("string(//Contact[PhoneNo='" + phoneNo + "']/SalesPhoneNo)");
