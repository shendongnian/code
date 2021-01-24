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
      var suggestionsListView = (new ListView() { ItemsSource = TextBox.GetSpellingError(spellingErrorIndex).Suggestions });
      
      TextBox.ToolTip = suggestionsListView;
      // Set ToolTip display time to one minute
      ToolTipService.SetShowDuration(TextBox, 60000);
    }
