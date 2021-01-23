    // Setup our little test.
    string sourceText = "ʤhello";
    byte[] searchBytes = Encoding.UTF8.GetBytes(sourceText);
    // Convert the bytes into a string we can search in.
    string searchText = Encoding.UTF8.GetString(searchBytes);
    int position = searchText.IndexOf("hello");
    // Get all text that is before the position we found.
    string before = searchText.Substring(0, position);
    // The length of the encoded bytes is the actual number of UTF8 bytes
    // instead of the position.
    int bytesBefore = Encoding.UTF8.GetBytes(before).Length;
    // This outputs Position is 1 and before is 2.
    Console.WriteLine("Position is {0} and before is {1}", position, bytesBefore);
