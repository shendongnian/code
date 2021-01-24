    string myString = "<b>Hello World</b>";
    // Encode the string.
    string myEncodedString = HttpUtility.HtmlEncode(myString);
    Console.WriteLine($"HTML Encoded string is: {myEncodedString}");
    StringWriter myWriter = new StringWriter();
    
    // Decode the encoded string.
    HttpUtility.HtmlDecode(myEncodedString, myWriter);
    string myDecodedString = myWriter.ToString();
    Console.Write($"Decoded string of the above encoded string is: {myDecodedString}");
