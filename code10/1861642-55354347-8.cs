      Regex regex = null; 
      try {
        regex = new Regex(
          patternTextBox.Text.Trim(), 
          RegexOptions.CultureInvariant,
          TimeSpan.FromSeconds(10));
      }
      catch (ArgumentException e) {
        if (patternTextBox.CanFocus)
          patternTextBox.Focus();
        MessageBox.Show($"Incorrect pattern: {e.Message}");
        return;
      } 
      try {
        foreach (Match match in regex.Matches(line)) {
          ...
        }
      }
      catch (RegexMatchTimeoutException) {
        //TODO: pattern is bad one, let user know it
      } 
