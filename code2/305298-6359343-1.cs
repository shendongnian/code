    //  ( = 'op--'  Opening Parenthesis
    //  ) = 'cp--'  Closing Parenthesis
    string id = "collectionName.get_Item(index)";
    // encode
    string encodedId = id.Replace("(", "op--").Replace(")", "cp--");
    // decode
    string decodedId = encodedId.Replace("op--", "(").Replace("cp--", ")");
