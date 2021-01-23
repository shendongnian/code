    string s1 = "<root>Test&#10;Test2</root>";
    string s2 = "<root>Test\nTest2</root>";
    XDocument doc1 = XDocument.Parse(s1);
    XDocument doc2 = XDocument.Parse(s2);
    Console.WriteLine(doc1.ToString());
    Console.WriteLine(doc2.ToString());
