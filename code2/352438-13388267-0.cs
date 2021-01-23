        Test.TestHeader header = new Test.TestHeader();
        header.Name = "BoB";
        Test.TestService SOAP = new Test.TestService();
        SOAP.TestHeaderValue = header;
        SOAP.GetServiceDetails(0,0,False);
