      Regex regex = null; 
      try {
        regex = new Regex(patternTextBox.Text.Trim(), RegexOptions.CultureInvariant);
      }
      catch (ArgumentException e) {
        if (patternTextBox.CanFocus)
          patternTextBox.Focus();
        MessageBox.Show($"Incorrect pattern: {e.Message}");
        return;
      } 
      foreach (Match match in regex.Matches(line))
      {
          ...
      }
