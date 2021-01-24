    private void OpenContextMenuOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
    {
      var mouseOverTextIndex = TextBox.GetCharacterIndexFromPoint(mouseEventArgs.GetPosition(TextBox), false);
      int spellingErrorIndex = this.TextBox.GetNextSpellingErrorCharacterIndex(mouseOverTextIndex, LogicalDirection.Forward);
      // Pointer is not over text or no spelling errors
      if (mouseOverTextIndex.Equals(-1) || spellingErrorIndex.Equals(-1))
      {
        return;
      }
    
      int startOfWordIndex = mouseOverTextIndex;
      while (startOfWordIndex != -1 && !TextBox.Text[startOfWordIndex].Equals(' '))
      {
        startOfWordIndex--;
      }
      var endOfWordIndex = TextBox.Text.IndexOf(" ", mouseOverTextIndex, StringComparison.OrdinalIgnoreCase);
      if (endOfWordIndex.Equals(-1))
      {
        endOfWordIndex = TextBox.Text.Length - 1;
      }
      
      //  Spelling error doesn't belong to current mouse over word
      if (spellingErrorIndex < startOfWordIndex || spellingErrorIndex > endOfWordIndex)
      {
        return;
      }
    
      using(CustomPopup popup = new CustomPopup())
      {
        foreach (var suggestion in this.TextBox.GetSpellingError(spellingErrorIndex).Suggestions)
        {
          var suggestionButton = new System.Windows.Forms.Button() { Text = suggestion };
          var eventArgs = new FixSpellingErrorEventArgs()
          {
            TextBox= box,
            WordStartIndex = startOfWordIndex,
            WordEndIndex = endOfWordIndex
            Suggestion = suggestion
          }
          
          suggestionButton.Click += (s, e) => FixSpellingError(eventArgs);
        
          popup.FlowLayoutPanel1.Controls.Add(suggestionButton);
        } 
        
        popup.SetDesktopLocation(mouseEventArgs.GetPosition(TextBox).X, mouseEventArgs.GetPosition(TextBox).Y);
        popup.ShowDialog(this);
      }
    }
    private void FixSpellingError(FixSpellingErrorEventArgs e)
    {
      e.TextBox.SelectionStart = e.WordStartIndex;
      e.TextBox.SelectionLength = e.WordEndIndex - e.WordStartIndex + 1;
      e.TextBox.SelectedText = e.Suggestion;
    }
