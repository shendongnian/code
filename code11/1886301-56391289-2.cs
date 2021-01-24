    using System.IO;
    using System.Linq;
    ...
    private static Dictionary<string, int> AllNames() {
      return File
        .ReadLines(@"C:\Users\HP\Desktop\картинки\results.txt")
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Select(item => item.Split(' ')) 
        .ToDictionary(items => items[0], 
                      items => int.Parse(items[1]));
    }
    
    private static bool NameExists(string name) {
      return AllNames().ContainsKey(name);
    }
    
    private static bool IsValidNameCharacter(char value) {
      if (value < ' ')
        return false;
      else if (value >= 'А' && value <= 'Я' || 
               value >= 'а' && value <= 'я' || 
               value == 'ё' ||
               value == 'Ё')
        return false;
    
      return true;
    }
