    interface IUndoable
    {
        void Undo();
    }
    class TextBox : IUndoable
    {
        void IUndoable.Undo()
        {
            Console.WriteLine("TextBox.Undo");
        }
    }
    class RichTexBox : TextBox
    {
        public new void Undo()
        {
            Console.WriteLine("RichTextBox.Undo");
        }
    }
    class FilthyRichTextBox : TextBox, IUndoable
    {
        public new void Undo()
        {
            Console.WriteLine("FilthyRichTextBox.Undo");
        }
    }
