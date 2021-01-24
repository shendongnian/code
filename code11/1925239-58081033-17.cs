      Func<string, string> convert = (source => {
        int index = 0;
        // we have match "m" with index "index"
        // out task is to provide a string which will be put instead of match
        return Regex.Replace(
          source, 
         "\"([^\"]|\"\")*\"", 
          m => {
            // now we have a match "m", with its value "m.Value"
            // its index "index" 
            // and we have to return a string which will be put instead of match
            // if you want unquoted value, i.e. abc"def instead of "abc""def"
            // string unquoted = Regex.Replace(
            //   m.Value, "\"+", match => new string('"', match.Value.Length / 2)); 
            return //TODO: put the relevant code here
          }
      });
