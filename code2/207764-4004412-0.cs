    //letterLookup['A'] is an IEnumerable<KeyValuePair<string,string>>...
    Console.WriteLine(string.Join(", ",
            letterLookup['A'].Select(kv=>kv.ToString()).ToArray()
        )); //Prints: [A_1, 1], [A_2, 2]
    Console.WriteLine(letterLookup['B'].Any()); //true
    Console.WriteLine(letterLookup['Z'].Any()); //false
