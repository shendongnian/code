    string input = "{ \"foo\": true, \"array\": [ 42, false, \"Hello!\", null ] }";
    dynamic value = new JsonReader().Read(input);
    // verify that it works
    Console.WriteLine(value.foo); // true
    Console.WriteLine(value.array[0]); // 42
    Console.WriteLine(value.array.Length); // 4
    
    string output = new JsonWriter().Write(value);
    // verify that it works
    Console.WriteLine(output); // {"foo":true,"array":[42,false,"Hello!",null]}
