    // Get selected character.
    int charIndex = textbox.SelectionStart;
    // Get line index from selected character.
    int lineIndex = textbox.GetLineFromCharIndex(charIndex);
    // Get line.
    string line = textbox.Lines[lineIndex];
