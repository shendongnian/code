      static void Main(string[] args)
      {
         string[] inputs = new string[6] { "E05S01", "S01E05", "0105", "105", "1x05", "1x5" };
         foreach (string input in inputs)
         {
            Console.WriteLine(FormatEpisodeTitle("Battlestar.Galactica", input, "mkv"));
         }
    
    
         Console.ReadLine();
      }
    
    
      private static string FormatEpisodeTitle(string showTitle, string identifier, string fileFormat)
      {
         //first make identifier upper case
         identifier = identifier.ToUpper();
    
         //normalize for SssEee & EeeSee
         if (identifier.IndexOf('S') > identifier.IndexOf('E'))
         {
            identifier = identifier.Substring(identifier.IndexOf('S')) + identifier.Substring(identifier.IndexOf('E'), identifier.IndexOf('S'));
         }
         
         //now get rid of S and replace E with x as needed:
         identifier = identifier.Replace("S", string.Empty).Replace("E", "X");
    
    
         //at this point, if there isn't an "X" we need one, as in 105 or 0105
         if (identifier.IndexOf('X') == -1)
         {
            identifier = identifier.Substring(0, identifier.Length - 2) + "X" + identifier.Substring(identifier.Length - 2);
         }
         
         //now split by the 'X'
         string[] identifiers = identifier.Split('X');
    
         // and put it back together:
         identifier = 'S' + identifiers[0].PadLeft(2, '0') + 'E' + identifiers[1].PadLeft(2, '0');
    
         //tack it all together 
         return showTitle + '.' + identifier + '.' + fileFormat;
    
      }
