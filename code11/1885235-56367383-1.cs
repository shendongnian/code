    var classA = Deserialize(XmlReader.Create(
        new StringReader("<CLASSA><syntaxid>A</syntaxid></CLASSA>"))
        );
    Console.WriteLine(classA.Syntaxid); // A
                
    var classB = Deserialize(
        XmlReader.Create(new StringReader("<CLASSB><syntaxid>B</syntaxid></CLASSB>"))
        );
    Console.WriteLine(classB.Syntaxid); // B
