    string stringToTransform = "AN UPERCASE TEST STRING";
    char[] stringCharacters = stringToTransform.ToCharArray();
    stringCharacters[0] = Char.ToLower(stringCharacters[0]); // first character
    stringCharacters[stringCharacters.Length - 1] = Char.ToLower(stringCharacters[stringCharacters.Length - 1]); // last character
    string transformedString = new string(stringCharacters);
