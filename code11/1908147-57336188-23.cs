    private void OpenContextMenuOnMouseMove(object sender, System.Windows.Input.MouseEventArgs mouseEventArgs)
    {
      var textBox = sender as System.Windows.Controls.TextBox;
      var mouseOverTextIndex = textBox.GetCharacterIndexFromPoint(mouseEventArgs.GetPosition(textBox), false);
      // Pointer is not over text
      if (mouseOverTextIndex.Equals(-1))
      {
        return;
      }
      int spellingErrorIndex = textBox.GetNextSpellingErrorCharacterIndex(mouseOverTextIndex, LogicalDirection.Forward);
      // No spelling errors
      if (spellingErrorIndex.Equals(-1))
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
        // Create clickable suggestions for the CustomPopup.
        foreach (var suggestion in textBox.GetSpellingError(spellingErrorIndex).Suggestions)
        {
          // Each Button represents a suggestion.
          var suggestionButton = new System.Windows.Forms.Button() { Text = suggestion };
          var fixSpellingErrorEventArgs = new FixSpellingErrorEventArgs()
          {
            TargetTextBox = textBox,
            WordStartIndex = startOfWordIndex,
            WordEndIndex = endOfWordIndex,
            Suggestion = suggestion
          };
          
          // The Button.Click callback will apply the selected fix
          suggestionButton.Click += (s, e) => FixSpellingError_OnButtonClicked(fixSpellingErrorEventArgs);
        
          // TODO::Replace the line with a public member of CustomPopup Form: CustomPopup.AddPanelContent(Control):void.
          // e.g. public void AddPanelContent(Control control) { this.FlowLayoutPanel1.Controls.Add(suggestionButton); }
          // and use it like: popup.AddPanelContent(suggestionButton);
          popup.FlowLayoutPanel1.Controls.Add(suggestionButton);
        } 
        
        popup.SetDesktopLocation((int) mouseEventArgs.GetPosition(textBox).X, (int) mouseEventArgs.GetPosition(textBox).Y);
        popup.ShowDialog(this);
      }
    }
    // The event handler that applies the selected fix.
    // Invoked on popup button clicked.
    private void FixSpellingError_OnButtonClicked(FixSpellingErrorEventArgs e)
    {
      // Select misspelled word and replace it with the selected fix
      e.TargetTextBox.SelectionStart = e.WordStartIndex;
      e.TargetTextBox.SelectionLength = e.WordEndIndex - e.WordStartIndex;
      e.TargetTextBox.SelectedText = e.Suggestion;
    }
