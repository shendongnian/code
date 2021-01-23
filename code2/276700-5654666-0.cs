    Dim xdoc As XDocument = <?xml version="1.0" encoding="UTF-8"?>
    									<root>
    										<client>
    											<Name>abc, xyz's</Name>
    											<DOB>2/1/1922</DOB>
    											<Number>1234567896</Number>
    											<Gender>unknown</Gender>
    										</client>
    										<Info>
    											<ID>1111111111</ID>
    											<Title>TITLE</Title>
    										</Info>
    										<BasicInfo>
    											<TransDate>3/16/2011</TransDate>
    											<Channel>1 + 1</Channel>
    											<Ind></Ind>
    											<Med></Med>
    											<Comment>This is comment</Comment>
    										</BasicInfo>
    									</root>
    
    
    			Console.WriteLine(xdoc.<root>.<client>.<Name>.Value())
    			Console.WriteLine("    {0}", xdoc.<root>.<client>.<Number>.Value())
    			Console.WriteLine("    {0}", xdoc.<root>.<Info>.<Title>.Value())
    			Console.WriteLine("    {0}", xdoc.<root>.<BasicInfo>.<Comment>.Value())
