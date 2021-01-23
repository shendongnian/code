    Encoding source = Encoding.UTF8;
    Encoding target = Encoding.GetEncoding(1252);
    byte[] input = new byte[2] { 0xC3, 0xA6 };  // This is the "hard way" to make æ.
    byte[] output = Encoding.Convert(source, target, input);
    string result = Encoding.GetEncoding(1252).GetString(output);
    Console.WriteLine(result);
