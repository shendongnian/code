    private void OpenContextMenuOnMouseMove(object sender, System.Windows.Input.MouseEventArgs mouseEventArgs)
    {
      var textBox = sender as System.Windows.Controls.TextBox;
      var mouseOverTextIndex = textBox.GetCharacterIndexFromPoint(mouseEventArgs.GetPosition(textBox), false);
      int spellingErrorIndex = textBox.GetNextSpellingErrorCharacterIndex(mouseOverTextIndex, LogicalDirection.Forward);
      // Pointer is not over text or no spelling errors
      if (mouseOverTextIndex.Equals(-1) || spellingErrorIndex.Equals(-1))
      {
        return;
      }
    
      int startOfWordIndex = mouseOverTextIndex;
      while (startOfWordIndex != -1 && !textBox.Text[startOfWordIndex].Equals(' '))
      {
        startOfWordIndex--;
      }
      var endOfWordIndex = textBox.Text.IndexOf(" ", mouseOverTextIndex, StringComparison.OrdinalIgnoreCase);
      if (endOfWordIndex.Equals(-1))
      {
        endOfWordIndex = textBox.Text.Length - 1;
      }
      
      //  Spelling error doesn't belong to current mouse over word
      if (spellingErrorIndex < startOfWordIndex || spellingErrorIndex > endOfWordIndex)
      {
        return;
      }
    
      using(CustomPopup popup = new CustomPopup())
      {
        foreach (var suggestion in textBox.GetSpellingError(spellingErrorIndex).Suggestions)
        {
          var suggestionButton = new System.Windows.Forms.Button() { Text = suggestion };
          var eventArgs = new FixSpellingErrorEventArgs()
          {
            TextBox = textBox,
            WordStartIndex = startOfWordIndex,
            WordEndIndex = endOfWordIndex,
            Suggestion = suggestion
          }
          
          suggestionButton.Click += (s, e) => FixSpellingError(eventArgs);
        
          popup.FlowLayoutPanel1.Controls.Add(suggestionButton);
        } 
        
        popup.SetDesktopLocation((int) mouseEventArgs.GetPosition(textBox).X, (int) mouseEventArgs.GetPosition(textBox).Y);
        popup.ShowDialog(this);
      }
    }
    private void FixSpellingError(FixSpellingErrorEventArgs e)
    {
      e.TextBox.SelectionStart = e.WordStartIndex;
      e.TextBox.SelectionLength = e.WordEndIndex - e.WordStartIndex;
      e.TextBox.SelectedText = e.Suggestion;
    }
