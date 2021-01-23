    int wordPosition = richTextBoxConversation.Find(s2); // Get position
    if (wordPosition > -1)
    {
      MessageBox.Show("Word found!");
      richTextBoxConversation.Select(wordPosition, s2.Length);
    }
    else
    {
      MessageBox.Show("Word not found!");
    }
     
