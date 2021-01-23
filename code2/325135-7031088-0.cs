    public string ReplaceColumn( string text, int col, List<string> newValues ){
      var sb = new StringBuilder();
      var lines = Regex.Split( text, "[\r\n]+" ); // split into lines
      for ( int row = 0; row < lines.Count ; row++ ){
        var line = lines[row];
        var columns = Regex.Split( line, "[\s]+" ); // split into columns
        
        // replace the chosen column for this row
        columns[col] = newvalues[row];
        // rebuild the line and store it
        sb.Append( String.Join( " ", columns );
        sb.Append( "\r\n" ); // or whatever line ending you want
        
      }
      return sb.ToString();
    }
