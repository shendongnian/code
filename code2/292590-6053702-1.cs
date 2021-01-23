    public bool IsKeyLine(string line) {
      if (!String.IsNullOrEmpty(line)) {
        //run two regexes - one to see if the line is of the general pattern of a "key" line
        //the second reg ex makes sure there isn't an ip address in the line, which would indicate that the line is part of the "value" and not the "key"
        return System.Text.RegularExpressions.RegEx.IsMatch(line, "^\s*\[\d{0,2}\]: ")
          && !System.Text.RegularExpressions.RegEx.IsMatch(line, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
      }
    }
