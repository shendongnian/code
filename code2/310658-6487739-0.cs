    // Re-create textReaderText from aParagraph.
    int intCharacter;
    char convertedCharacter;
    StringWriter strWriter = new StringWriter();
    strReader = new StringReader(aParagraph);
    while (true)
    {
        intCharacter = strReader.Read();
        // Check for the end of the string 
        // before converting to a character.
        if (intCharacter == -1) break;
        convertedCharacter = Convert.ToChar(intCharacter); // CONVERT TO CHAR HERE
        if (convertedCharacter == '.')
        {
            strWriter.Write(".\n\n");
            // Bypass the spaces between sentences.
            strReader.Read();
            strReader.Read();
        }
        else
        {
            strWriter.Write(convertedCharacter);
        }
    }
