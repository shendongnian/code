    private static void Test(string stream)
    {
        XDocument doc = XDocument.Parse(stream);
        var list = from hello in doc.Descendants("node2")
                   where attacker.Element("text").Value.StartsWith("Welcome")
                   select attacker.Element("text").Value;
        foreach (var x in attackList)
        {
            Console.WriteLine(x);
        }
    }
