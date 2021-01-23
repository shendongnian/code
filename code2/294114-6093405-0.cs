    var input = "Blue Cross Blue Shield 12356";
    var sb = new StringBuilder();
    foreach (var ch in input) {
      if (char.IsUpper(ch)) { // only keep uppercase
        sb.Append(ch);
      }
    }
    sb.ToString(); // "BCBS"
