    private IEnumerable<string> ReturnAllMessages( IEnumerable<string> lines )
    {
      bool isMessage = false;
      foreach (var line in lines) {
        if (line.StartsWith('Msg =')) {
          isMessage = true;
          // set a flag that the next lines are part of the message
          // this would exclude the rest of the line from the results
          // if you want it, you could use:
          // yield return line.Substring('Msg ='.Length));
          continue;
        }
        if (line.StartsWith('Answer =')) {
          // remove the flag
          isMessage = false;
          continue;
        } 
        if (isMessage) {
          // yield a line that is a message
          yield return line;
        }
      }
    }
