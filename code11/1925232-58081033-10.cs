      Func<string, string> convert = (source => {
        int index = 0;
        // we have match "m" with index "index"
        // out task is to provide a string which will be put instead of match
        return Regex.Replace(
          source, 
         "\"([^\"]|\"\")*\"", 
          m => int.TryParse(m.Value, out int _drop)
            ? $"\"{{{++index}}}\"") // if match is a valid integer, replace it
            : m.Value);             // if not, keep intact 
      });
