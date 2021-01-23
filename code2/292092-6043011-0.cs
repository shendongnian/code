    public class IUndoable
    {
    }
    public class TextBox : IUndoable
    {
       public new void Undo() { Console.WriteLine ("RichTextBox.Undo"); }
    }
    public class RichTextBox : TextBox
    {
      public new void Undo() { Console.WriteLine ("RichTextBox.Undo"); }
    }
