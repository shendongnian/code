    /// <summary>
    /// This method highlights the assigned text with the specified color.
    /// </summary>
    /// <param name="textToMark">The text to be marked.</param>
    /// <param name="color">The new Backgroundcolor.</param>
    /// <param name="richTextBox">The RichTextBox.</param>
    /// <param name="startIndex">The zero-based starting caracter position.</param>
    public static void ChangeTextcolor(string textToMark, Color color, RichTextBox richTextBox, int startIndex)
    {
        if (startIndex < 0 || startIndex > textToMark.Length-1) startIndex = 0;
        System.Drawing.Font newFont = new Font("Verdana", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178, false);
        try
        {               
            foreach (string line in richTextBox.Lines)
            { 
                if (line.Contains(textToMark))
                {
                    richTextBox.Select(startIndex, line.Length);
                    richTextBox.SelectionBackColor = color;
                }
                startIndex += line.Length +1;
            }
        }
        catch
        { }
    }
