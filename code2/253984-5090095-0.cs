    private static string getChecksum(string sentence)
    {
      //Start with first Item
      int checksum= Convert.ToByte(sentence[sentence.IndexOf('$')+1]);
      // Loop through all chars to get a checksum
      for (int i=sentence.IndexOf('$')+2 ; i<sentence.IndexOf('*') ; i++)
      {
        // No. XOR the checksum with this character's value
        checksum^=Convert.ToByte(sentence[i]);				
      }
      // Return the checksum formatted as a two-character hexadecimal
      return checksum.ToString("X2");
    }
