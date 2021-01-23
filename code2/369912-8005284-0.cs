    public bool TryParseDouble(string input, out double value){
      if(string.IsNullorWhiteSpace(input)) return false;
      const string Numbers = "0123456789.";
      var numberBuilder = new StringBuilder();
      foreach(char c in input) {
        if(Numbers.IndexOf(c) > -1)
          numberBuilder.Append(c);
      }
      return double.TryParse(numberBuilder.ToString(), out value);
    }
