    static class ExtensionsForTextReader
    {
         public static IEnumerable<string> ReadLines (this TextReader reader, char delimeter)
         {
                List<char> chars = new List<char> ();
                while (reader.Peek() >= 0)
                {
                    char c = (char)reader.Read ();
                    if (c == delimeter) {
                        yield return new string(chars);
                        chars.Clear ();
                        continue;
                    }
                    chars.Add(c);
                }
         }
