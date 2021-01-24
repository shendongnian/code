     private static void WriteCharacters(int numSpaces, int numChars) {
      Console.Write(new string('*', numChars));
      Console.Write(new string(' ', numSpaces));
      Console.Write(new string('*', numChars));
      Console.WriteLine();
    }
