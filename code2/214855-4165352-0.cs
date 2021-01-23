    Dictionary<char,int> asciilist = new Dictionary<char,int>();
    string s = "AB-1233-444";
    string[] splitstrings = s.Split('-');
    foreach( char c in splitstrings[0]){
      asciilist.Add( c, (int)c );
    }
