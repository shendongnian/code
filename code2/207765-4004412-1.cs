    //letterLookup['A'] is an IEnumerable<KeyValuePair<string,string>>...
    Console.WriteLine(string.Join(", ",
            letterLookup['A'].Select(kv=>kv.ToString()).ToArray()
        )); // [A_1, 1], [A_2, 2]
    Console.WriteLine(new XElement("root",
            letterLookup['B'].Select(kv=>new XElement(kv.Key,kv.Value))
        ));// <root><B_1>3</B_1><B_2>4</B_2></root>
    Console.WriteLine(letterLookup['B'].Any()); //true
    Console.WriteLine(letterLookup['Z'].Any()); //false
