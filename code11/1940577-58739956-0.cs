    const string xml = @"
        <Courses xmlns=""http://xml"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""Courses.xsd"">
            <Course>
                <Code Undergrad=""240""/>
                <Name>Biology</Name>
                <Instructor>
                <Name>
                <First>John</First>
                <Last>Doe</Last>
                </Name>
                <Contact>
                <Phone>898-989-8989</Phone>
                </Contact>
                </Instructor>
                <Room>515</Room>
            </Course>
        </Courses>";
    
    using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(xml)))
    {
        var pdoc = new XPathDocument(stream);
        var pNav = pdoc.CreateNavigator();
    
        var manager = new XmlNamespaceManager(pNav.NameTable);
        manager.AddNamespace("cs", "http://xml");
    
        var iterator = pNav.Select("/cs:Courses/cs:Course", manager);
    
        while (iterator.MoveNext())
        {
            XPathNodeIterator it = iterator.Current.Select("Name");
            it.MoveNext();
            string courseName = it.Current.Value;
            it = iterator.Current.Select("Code");
            it.MoveNext();
            string courseCode = it.Current.Value;
            Console.WriteLine("{0} {1}", courseName, courseCode);
        }
    }
