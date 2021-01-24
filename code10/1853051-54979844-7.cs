    class Program
      {
        static void Main(string[] args)
        {
          // this is your array of strings (lines)
          string[] lines = new string[1] {
            "2 3 9 14 23 26 34 36 39 40 52 55 59 63 67 76 85 86 90 93 99 108 114:275:5 8 1 14 10 6 10 18 12 25 7 40 1 30 18 8 2 1 5 21 10 2 21"
          };
    
          // this dictionary contains the line index and the list of indexes containing number 14
          // in that line
          Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
    
          // iterating over lines array
          for (int i = 0; i < lines.Length; i++)
          {
            // creating the list of indexes and the dictionary key
            List<int> indexes = new List<int>();
            dict.Add(i, indexes);
            // splitting the line by space to get numbers
            string[] lineElements = lines[i].Split(' ');
            // iterating over line elements
            for (int j = 0; j < lineElements.Length; j++)
            {
    		  // printing all indexes of the current line
              Console.WriteLine(string.Format("Element index: {0}", j));
            }
          }
    
          Console.ReadLine();
        }
      }
