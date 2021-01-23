    public class TextBoxExtension : TextBox
    {
     public TextBoxExtension (){ }
 
     public int CurrentLineIndex
     {
        get { return this.GetLineFromCharIndex(this.SelectionStart) + 1; }
     }
    }
