    private readonly List<HighLight> _highLights = new List<HighLight>();
    private class HighLight
    {
      public int Start { get; set; }
      public int End { get; set; }
    }
    
    public void SetHighLighting(string text)
    {
        
        // Clear Previous HighLighting
        ClearHighLighting();
        
        if (text.Length > 0)
        {
            int startPosition = 0;
            int foundPosition = 0;            
            while (foundPosition > -1)
            {
                foundPosition = richTextBox1.Find(text, startPosition, RichTextBoxFinds.None);
                if (foundPosition >= 0)
                {
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    int endindex = text.Length;
                    richTextBox1.Select(foundPosition, endindex);                        
                    startPosition = foundPosition + endindex;                        
                    _highLights.Add(new HighLight() { Start = foundPosition, End = endindex });
                }
            }
        }
    }
    
    public void ClearHighLighting()
    {
        foreach (var highLight in  _highLights)
        {
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            richTextBox1.Select(highLight.Start, highLight.End);                        
        }
        _highLights.Clear();
    }
