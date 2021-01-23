    if (s1.Contains(s2))
    {
      MessageBox.Show("Word found!");
      int wordPosition = richTextBoxConversation.Find(s2); // Get position
      richTextBoxConversation.Select(wordPosition, s2.Length);
    }
