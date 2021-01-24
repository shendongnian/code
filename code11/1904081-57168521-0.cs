    public static class RichTextBoxExtensions
    {
      //this is THE EXTENSION method
      public static void AppendText(this RichTextBox box, string text, Color color)
      {
        ...
      }
    }
    //this is YOUR code
    void AppendText(RichTextBox box, Color color, string text)
    {
        //call THE EXTENSION code
        box.AppendText(color, text);
    }
    //now your code, calls your code, calls the extension
    AppendText(rtbMessages, Color.Red, "Yarr Matey, this be a test");
