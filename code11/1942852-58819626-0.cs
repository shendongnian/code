    static string Encrypt(string message)
    {
      // Let's not hardcode
      char[] alphabet = Enumerable
        .Range('a', 'z' - 'a')
        .Select(c => (char) c)
        .ToArray();
      string secretMessage = message.ToLower();
      char[] secretMessageChar = secretMessage.ToCharArray();
      char[] encryptedMessage = new char[secretMessageChar.Length];
      for (int i = 0; i < secretMessage.Length; i++)
      {
        if (!Char.IsLetter(secretMessageChar[i]))
        {
          continue;
        }
        char letter = secretMessageChar[i];
        int caesarLetterIndex = (Array.IndexOf(alphabet, letter) + 3) % 26;
        char encryptedCharacter = alphabet[caesarLetterIndex];
        encryptedMessage[i] = encryptedCharacter;
      }
      // Shorter version of string.Join("", ...)
      return String.Concat(encryptedMessage);
    }
