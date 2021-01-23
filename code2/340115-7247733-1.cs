    String s = "\u30a2\u30c3\u30d7\u30ed";
    s.Dump();     // original string
    var bytes = Encoding.UTF8.GetBytes(s);      
    bytes.Dump(); // see UTF-8 encoded byte sequence
    string key = Encoding.UTF8.GetString(bytes);
    key.Dump();   // contents restored
