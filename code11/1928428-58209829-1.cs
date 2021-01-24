    private static string FirstAndLastLetterOfWordToLowercase(string stringToTransform)
    {
       char[] stringCharacters = stringToTransform.ToCharArray();
       for (int charIndex = 0; charIndex < stringCharacters.Length; charIndex++)
       {
          char currentCharacter = stringCharacters[charIndex];
          if (!isWordSepparator(currentCharacter))
          {
             if (charIndex == 0 || charIndex == stringCharacters.Length - 1 // is first or last character
                || (charIndex > 0 && isWordSepparator(stringCharacters[charIndex - 1])) // previous character was a word separator
                || isWordSepparator(stringCharacters[charIndex + 1])) // next character is a word separator
             {
                stringCharacters[charIndex] = char.ToLower(currentCharacter);
             }
          }
       }
       return new string(stringCharacters);
    }
    
    private static bool isWordSepparator(char character)
    {
       return char.IsPunctuation(character) || char.IsSeparator(character);
    }
